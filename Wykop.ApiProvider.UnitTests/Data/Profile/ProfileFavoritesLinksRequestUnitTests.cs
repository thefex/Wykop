using System;
using System.Net.Http;
using NUnit.Framework;
using Wykop.ApiProvider.Data.Link.Profile;

namespace Wykop.ApiProvider.UnitTests.Data.Profile
{
    [TestFixture]
    public class ProfileFavoritesLinksRequestUnitTests : ProfileLinksRequestTestFixture
    {
        private ProfileFavoritesLinksRequest systemUnderTests;

        [SetUp]
        public void SetupTests()
        {
            systemUnderTests = new ProfileFavoritesLinksRequest("testUsername")
            {
                RequestedListId = 3,
                RequestedPage = 123456
            };

            string expectedUriString = UnitTestsConstants.WykopHostUrl + "Profile/Favorites/param1/" +
                                       systemUnderTests.ProfileUsername + "/param2/3" +
                                       "/appkey," + UnitTestsConstants.AppKey + ",page,123456";
            ExpectedRequestUri = new Uri(expectedUriString);
            WykopRequest = systemUnderTests;
        }

        [Test]
        public void BuildRestRequest_RequestShouldBeSendByGetMethod()
        {
            Assert.AreEqual(HttpMethod.Get, systemUnderTests.BuildRestRequest().Method);
        }
    }
}