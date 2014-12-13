using System;
using System.Linq;
using System.Net.Http;
using NUnit.Framework;
using RestSharp.Portable;
using Wykop.ApiProvider.Data.LinkRequest.Links;
using Wykop.ApiProvider.Data.Types;

namespace Wykop.ApiProvider.UnitTests.Data.Link.Links
{
    [TestFixture]
    public class PromotedMainLinksRequestUnitTests : LinksRequestTestFixture
    {
        /* Method Parameters: none
         * API Parameters:
               appkey – klucz aplikacji
               page – strona
	           sort – day (ostatnie 24 godz), week (ostatnie 7 dni), month (ostatnie 30 dni)
         * POST Parameters: none
         */

        private const int requestedPage = 2;
        private readonly SortType sortType = SortType.CreateSortByDay();
        private readonly Uri expectedUriResult = new Uri("http://a.wykop.pl/Links/Promoted/appkey," + 
            UnitTestsConstants.AppKey + ",page,2,sort,day");
        private PromotedMainLinksRequest promotedMainLinksRequest;

        [SetUp]
        public void SetupTests()
        {
            promotedMainLinksRequest = new PromotedMainLinksRequest()
            {
                RequestedPage = requestedPage,
                SortType = sortType
            };
        }

        [Test]
        public void BuildRestRequest_IsProperResourceUrlCreated()
        {
            var restRequest = promotedMainLinksRequest.BuildRestRequest();

            Uri buildedRequestUri = RestClient.BuildUri(restRequest);

            Assert.AreEqual(expectedUriResult, buildedRequestUri, "Request URI is invalid.");
        }
            
        [Test]
        public void BuildRestRequest_ProperApiSignHttpHeaderShouldBeSet()
        {
            var restRequest = promotedMainLinksRequest.BuildRestRequest();

            AssertThatRequestIsCorrectlySigned(restRequest, expectedUriResult);
        }

        [Test]
        public void BuildRestRequest_PostBodyShouldBeEmpty()
        {
            var restRequest = promotedMainLinksRequest.BuildRestRequest();
            
            bool containsPostParameters = restRequest.Parameters.Any(x =>
                (restRequest.Method == HttpMethod.Post && x.Type == ParameterType.GetOrPost) ||
                x.Type == ParameterType.RequestBody);

            Assert.IsFalse(containsPostParameters, "Request contains post parameters");
        }
    }
}