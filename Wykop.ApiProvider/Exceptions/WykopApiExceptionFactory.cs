using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Wykop.ApiProvider.Common.Attributes;
using Wykop.ApiProvider.Exceptions.ApiExceptions;
using Wykop.ApiProvider.Exceptions.ApiExceptions.Factories;

namespace Wykop.ApiProvider.Exceptions
{
    public class WykopApiExceptionFactory
    {
        private readonly Dictionary<ApiErrorCode, IWykopApiExceptionFactory> _errorCodeExceptionsMap;

        public WykopApiExceptionFactory()
        {
            _errorCodeExceptionsMap = GetErrorCodeToExceptionMap();
        }

        private Dictionary<ApiErrorCode, IWykopApiExceptionFactory> GetErrorCodeToExceptionMap()
        {
            var exceptionsAssembly = typeof (WykopApiExceptionFactory).GetTypeInfo().Assembly;


            return
                exceptionsAssembly.DefinedTypes.Where(currentType => currentType.IsClass && !currentType.IsAbstract &&
                                                                     typeof (IWykopApiExceptionFactory).GetTypeInfo()
                                                                         .IsAssignableFrom(currentType))
                    .SelectMany(type =>
                        type.GetCustomAttributes<WykopApiExceptionFactoryAttribute>()
                            .Select(wykopApiExceptionAttribute => new
                            {
                                ErrorCode = wykopApiExceptionAttribute.ApiErrorCode,
                                ExceptionFactory = (IWykopApiExceptionFactory) Activator.CreateInstance(type.GetType())
                            }))
                    .ToDictionary(x => x.ErrorCode, x => x.ExceptionFactory);
        }

        public WykopApiException GenerateExceptionFromErrorCode(ApiErrorCode apiErrorCode, string requestUrl)
        {
            if (!_errorCodeExceptionsMap.ContainsKey(apiErrorCode))
                throw new InternalLibraryException("Type: " + apiErrorCode +
                                                   "is not mapped in library. Contact library author.");

            return _errorCodeExceptionsMap[apiErrorCode].GetWykopApiException(apiErrorCode, requestUrl);
        }
    }
}