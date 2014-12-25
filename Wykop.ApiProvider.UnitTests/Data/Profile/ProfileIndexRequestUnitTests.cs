using System;
using NUnit.Framework;
using Wykop.ApiProvider.Data.Exceptions;
using Wykop.ApiProvider.Data.Link.Profile;

namespace Wykop.ApiProvider.UnitTests.Data.Profile
{
    [TestFixture]
    public class ProfileIndexRequestUnitTests : WykopRequestBaseTestFixture
    {
        private ProfileIndexLinksRequest systemUnderTest;
        [SetUp]
        public void SetupUnitTests()
        {
            systemUnderTest = new ProfileIndexLinksRequest("testUsername");

            WykopRequest = systemUnderTest;
            string expectedUriString = UnitTestsConstants.WykopHostUrl + "Profile/Index/param1/" + 
                                       systemUnderTest.ProfileUsername + "/" +
                                      "appkey," + UnitTestsConstants.AppKey;
            ExpectedRequestUri = new Uri(expectedUriString);
        }

        [Test]
        public void BuildRestRequest_RequestedUsernameIsEmpty_ShouldThrowRequestCouldNotBeBuild()
        {
            var sut = new ProfileIndexLinksRequest("");

            Assert.Throws<RequestCouldNotBeBuildException>( () => sut.BuildRestRequest());
        }
    }
}