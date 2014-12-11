using Wykop.ApiProvider.Common.Attributes;

namespace Wykop.ApiProvider.Exceptions.ApiExceptions.Factories
{
    [WykopApiExceptionFactory(ApiErrorCode.InvalidApiKey)]
    public class InvalidApiKeyExceptionFactory : IWykopApiExceptionFactory
    {
        public WykopApiException GetWykopApiException(ApiErrorCode errorCode, string requestUrl)
        {
            var exceptionReason = "Invalid ApplicationKey was send with wykop api request.\n " +
                                  "Have you configured WykopApi with correct application key?";

            return new InvalidWykopApiRequestException(errorCode, requestUrl, exceptionReason);
        }
    }
}