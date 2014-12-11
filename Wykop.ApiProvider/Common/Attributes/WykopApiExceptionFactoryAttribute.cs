using System;
using Wykop.ApiProvider.Exceptions.ApiExceptions;

namespace Wykop.ApiProvider.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class WykopApiExceptionFactoryAttribute : Attribute
    {
        public WykopApiExceptionFactoryAttribute(ApiErrorCode errorCode)
        {
            ApiErrorCode = errorCode;
        }

        public ApiErrorCode ApiErrorCode { get; private set; }
    }
}