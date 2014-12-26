using System;
using System.Net.Http;
using NUnit.Framework;
using Wykop.ApiProvider.Data.Link.Profile;

namespace Wykop.ApiProvider.UnitTests.Data.Profile
{
    [TestFixture]
    public class ProfileAddedLinksRequestsTests : ProfileLinksRequestTestFixture
    {
        private ProfileAddedLinksRequest systemUnderTest;

        [SetUp]
        public void SetupTests()
        {
            systemUnderTest = new ProfileAddedLinksRequest("testUsername")
            {
                RequestedPage = 2
            };

            string expectedUriString = UnitTestsConstants.WykopHostUrl + "Profile/Added/" +
                                       systemUnderTest.ProfileUsername +
                                       "/appkey," + UnitTestsConstants.AppKey + ",page,2";
            ExpectedRequestUri = new Uri(expectedUriString);
            WykopRequest = systemUnderTest;
        }

        [Test]
        public void BuildRestRequest_AssertThatRequestIsSendedByGet()
        {
            Assert.AreEqual(HttpMethod.Get, systemUnderTest.BuildRestRequest().Method);
        }
    }
}