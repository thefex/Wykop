using RestSharp.Portable;
using Wykop.ApiProvider.Exceptions;

namespace Wykop.ApiProvider.Common.Extensions
{
    public static class RestRequestExtensions
    {
        public static void SignWykopRequest(this RestRequest request)
        {
            if (!WykopApiConfiguration.IsConfigured())
                throw new NotConfiguredApiException("You need to call WykopApi");
        }
    }
}