using System;
using System.Linq;
using NUnit.Framework;
using RestSharp.Portable;
using Wykop.ApiProvider.Common.Extensions;

namespace Wykop.ApiProvider.UnitTests.Data.Link
{
    [TestFixture]
    public abstract class LinksRequestTestFixture 
    {
        protected RestClient RestClient { get; private set; }

        [SetUp]
        public void TestsSetup()
        {
            RestClient = new RestClient(UnitTestsConstants.WykopHostUrl);
        }

        protected void AssertThatRequestIsCorrectlySigned(RestRequest request, Uri expectedUri)
        {
            string apiSignStringToHash = UnitTestsConstants.ApiSecret + expectedUri.OriginalString;
            string apiSignHash = HashHelper.CalculateMD5Hash(apiSignStringToHash);

            var apiSignHeaderParameter = 
                request.Parameters.SingleOrDefault(x => x.Name == "apisign" && x.Type == ParameterType.HttpHeader);

            Assert.NotNull(apiSignHeaderParameter, "Request doesn't contain apisign http header.");
            Assert.AreEqual(apiSignHash, (string)apiSignHeaderParameter.Value, "APISign value is invalid.");
        }
    }
}