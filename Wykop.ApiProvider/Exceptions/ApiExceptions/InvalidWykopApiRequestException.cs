using System.Collections.Generic;

namespace Wykop.ApiProvider.Exceptions.ApiExceptions
{
    public class InvalidWykopApiRequestException : WykopApiException
    {
        public InvalidWykopApiRequestException(ApiErrorCode errorCode, string requestUrl) : base(errorCode, requestUrl)
        {
        }

        public InvalidWykopApiRequestException(ApiErrorCode errorCode, string requestUrl, string reason) : base(errorCode, requestUrl, reason)
        {
        }
    }
}