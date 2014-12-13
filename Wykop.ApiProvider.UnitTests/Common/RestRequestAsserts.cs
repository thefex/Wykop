using System.Linq;
using System.Net.Http;
using NUnit.Framework;
using RestSharp.Portable;

namespace Wykop.ApiProvider.UnitTests.Common
{
    public static class RestRequestAsserts
    {
        public static void AssertThatRequestHasEmptyPostBody(this RestRequest restRequest)
        {
            var containsPostParameters = restRequest.Parameters.Any(x =>
                (restRequest.Method == HttpMethod.Post && x.Type == ParameterType.GetOrPost) ||
                x.Type == ParameterType.RequestBody);

            Assert.IsFalse(containsPostParameters, "Request contains post parameters");
        }
    }
}