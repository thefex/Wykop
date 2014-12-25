using System;
using NUnit.Framework;
using Wykop.ApiProvider.Data.Link.Profile;

namespace Wykop.ApiProvider.UnitTests.Data.Profile
{
    [TestFixture]
    public class ProfilePublishedLinksRequestUnitTests : ProfileLinksRequestTestFixture
    {
        private ProfilePublishedLinksRequest systemUnderTest;

        [SetUp]
        public void SetupTests()
        {
            systemUnderTest = new ProfilePublishedLinksRequest("testUsername")
            {
                RequestedPage = 123
            };

            string expectedUriString = UnitTestsConstants.WykopHostUrl + "Profile/Published/param1/" +
                                       systemUnderTest.ProfileUsername + "/appkey," +
                                       UnitTestsConstants.AppKey + ",page,123";
            ExpectedRequestUri = new Uri(expectedUriString);
            WykopRequest = systemUnderTest;
        }
    }
}