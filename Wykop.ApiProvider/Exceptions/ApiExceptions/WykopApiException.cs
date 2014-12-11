using System;

namespace Wykop.ApiProvider.Exceptions.ApiExceptions
{
    public class WykopApiException : InvalidOperationException
    {
        public WykopApiException(ApiErrorCode errorCode, string requestUrl)
            : this(errorCode, requestUrl, "WykopAPI returned error.")
        {
        }

        public WykopApiException(ApiErrorCode errorCode, string requestUrl, string reason)
            : base(reason)
        {
            ErrorCode = errorCode;
        }

        public ApiErrorCode ErrorCode { get; private set; }
        public string RequestUrl { get; private set; }
    }
}