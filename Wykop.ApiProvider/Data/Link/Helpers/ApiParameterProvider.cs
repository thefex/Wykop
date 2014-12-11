using RestSharp.Portable;
using Wykop.ApiProvider.Common;

namespace Wykop.ApiProvider.Data.LinkRequest.Helpers
{
    public class ApiParameterProvider
    {
        public static Parameter GetApplicationKeyParameter()
        {
            return new Parameter()
            {
                Name = "appkey",
                Value = WykopApiConfiguration.ApiKey,
                Type = ParameterType.UrlSegment
            };
        }

        public static Parameter GetPageParameter(int pageNumber)
        {
            return new Parameter()
            {
                Name = "page",
                Value = pageNumber,
                Type = ParameterType.UrlSegment
            };
        }
    }
}