using System;
using System.Net.Http;
using NUnit.Framework;
using Wykop.ApiProvider.Data.Link.Profile;

namespace Wykop.ApiProvider.UnitTests.Data.Profile
{
    [TestFixture]
    public class ProfileCommentedLinksRequestUnitTests : ProfileLinksRequestTestFixture
    {
        private ProfileCommentedLinksRequest systemUnderTest;

        [SetUp]
        public void SetupTests()
        {
            systemUnderTest = new ProfileCommentedLinksRequest("testUsername")
            {
                RequestedPage = 4
            };

            string expectedUriString = UnitTestsConstants.WykopHostUrl + "Profile/Commented/param1/" +
                                       systemUnderTest.ProfileUsername + "/appkey," + UnitTestsConstants.AppKey +
                                       ",page,4";
            ExpectedRequestUri = new Uri(expectedUriString);
            WykopRequest = systemUnderTest;
        }

        [Test]
        public void BuildRestRequest_AssertThatRequestHttpMethodIsGet()
        {
            Assert.AreEqual(HttpMethod.Get, systemUnderTest.BuildRestRequest().Method);
        }
    }
}