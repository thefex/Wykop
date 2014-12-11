namespace Wykop.ApiProvider.Exceptions.ApiExceptions.Factories
{
    internal interface IWykopApiExceptionFactory
    {
        WykopApiException GetWykopApiException(ApiErrorCode apiErrorCode, string requestUrl);
    }
}