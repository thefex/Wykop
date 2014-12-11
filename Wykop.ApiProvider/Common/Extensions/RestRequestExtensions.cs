using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using RestSharp.Portable;
using Wykop.ApiProvider.Common.Constants;
using Wykop.ApiProvider.Exceptions;

namespace Wykop.ApiProvider.Common.Extensions
{
    public static class RestRequestExtensions
    {
        public static void SignWykopRequest(this RestRequest request)
        {
            if (!WykopApiConfiguration.IsConfigured())
                throw new NotConfiguredApiException("You need to call WykopApiConfiguration.SetApiKey and secret");

            string postParameterString = request.GetPostParametersStringSepareted();
            string resourceUrl = ApiConstants.HostUrl + request.Resource;
            string signedApiHash = HashHelper.CalculateMD5Hash(WykopApiConfiguration.ApiSecret + resourceUrl + postParameterString);

            request.AddHeader("apisign", signedApiHash);
        }

        private static string GetPostParametersStringSepareted(this RestRequest request)
        {
            List<string> postValues = new List<string>();

            if (request.Method == HttpMethod.Post)
            {
                postValues = request.Parameters
                    .Where(x => 
                        x.Type == ParameterType.GetOrPost)
                    .Select(x => x.Value.ToString())
                    .ToList();
            }
                

            if (!postValues.Any())
                return string.Empty;

            return postValues
                .OrderBy(x => x)
                .Aggregate((previousParameter, currentParameter) => previousParameter + "," + currentParameter);
        }
    }
}