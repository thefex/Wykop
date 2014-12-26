using System;
using System.Net.Http;
using NUnit.Framework;
using Wykop.ApiProvider.Data.Link.Profile;

namespace Wykop.ApiProvider.UnitTests.Data.Profile
{
    [TestFixture]
    public class ProfileDiggedLinksRequestUnitTests : ProfileLinksRequestTestFixture
    {
        private ProfileDiggedLinksRequest systemUnderTest;

        [SetUp]
        public void SetupUnitTests()
        {
            systemUnderTest = new ProfileDiggedLinksRequest("testUsername")
            {
                RequestedPage = 1231
            };

            string expectedUriString = UnitTestsConstants.WykopHostUrl + "Profile/Digged/" +
                                       systemUnderTest.ProfileUsername + "/appkey," + UnitTestsConstants.AppKey +
                                       ",page,1231";
            ExpectedRequestUri = new Uri(expectedUriString);
            WykopRequest = systemUnderTest;
        }

        [Test]
        public void BuildRestRequest_AssertThatRequestIsSendByGetMethod()
        {
            Assert.AreEqual(HttpMethod.Get, systemUnderTest.BuildRestRequest().Method);
        }
    }
}