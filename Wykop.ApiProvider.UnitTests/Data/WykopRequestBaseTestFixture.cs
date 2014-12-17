﻿using System;
using System.Linq;
using NUnit.Framework;
using RestSharp.Portable;
using Wykop.ApiProvider.Common.Extensions;
using Wykop.ApiProvider.Data;
using Wykop.ApiProvider.Data.LinkRequest;

namespace Wykop.ApiProvider.UnitTests.Data
{
    [TestFixture]
    public abstract class WykopRequestBaseTestFixture
    {
        protected RestClient RestClient { get; private set; }
        protected WykopRequestBase WykopRequest { get; set; }
        protected Uri ExpectedRequestUri { get; set; }

        [SetUp]
        public void TestsSetup()
        {
            RestClient = new RestClient(UnitTestsConstants.WykopHostUrl);
        }

        [Test]
        public void BuildRestRequest_IsProperResourceUrlCreated()
        {
            var restRequest = WykopRequest.BuildRestRequest();
            Uri buildedRequestUri = RestClient.BuildUri(restRequest);

            Assert.AreEqual(ExpectedRequestUri, buildedRequestUri, "Request URI is invalid.");
        }

        [Test]
        public void BuildRestRequest_ProperApiSignHttpHeaderShouldBeSet()
        {
            var restRequest = WykopRequest.BuildRestRequest();

            AssertThatRequestIsCorrectlySigned(restRequest, ExpectedRequestUri);
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