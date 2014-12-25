using System;
using NUnit.Framework;
using Wykop.ApiProvider.Data.Exceptions;
using Wykop.ApiProvider.Data.Link.Profile;

namespace Wykop.ApiProvider.UnitTests.Data.Profile
{
    [TestFixture]
    public class ProfileBuriedLinksRequestUnitTests : ProfileLinksRequestTestFixture
    {
        private ProfileBuriedLinksRequest systemUnderTest;

        [SetUp]
        public void SetupTests()
        {
            systemUnderTest = new ProfileBuriedLinksRequest("testUsername", "testUserKey")
            {
                RequestedPage = 3
            };

            string expectedUriString = UnitTestsConstants.WykopHostUrl + "Profile/Buried/param1/" +
                                       systemUnderTest.ProfileUsername +
                                       "/userkey," + systemUnderTest.UserKey + ",appkey," + UnitTestsConstants.AppKey +
                                       ",page,3";
            ExpectedRequestUri = new Uri(expectedUriString);
            WykopRequest = systemUnderTest;
        }

        [Test]
        public void BuildRestRequest_WhenUserKeyIsEmptyOrNull_RequestCouldNotBeBuildExceptionShouldBeThrown()
        {   
            Assert.Throws<RequestCouldNotBeBuildException>(() =>
                new ProfileBuriedLinksRequest("testUsername", string.Empty).BuildRestRequest());
        }
    }
}