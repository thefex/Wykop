using System;
using NUnit.Framework;
using Wykop.ApiProvider.Data.Exceptions;
using Wykop.ApiProvider.Data.Link.Profile;

namespace Wykop.ApiProvider.UnitTests.Data.Profile
{
    [TestFixture]
    public class ProfileIndexRequestUnitTests : ProfileLinksRequestTestFixture
    {
        private ProfileIndexLinksRequest systemUnderTest;
        [SetUp]
        public void SetupUnitTests()
        {
            systemUnderTest = new ProfileIndexLinksRequest("testUsername");

            WykopRequest = systemUnderTest;
            string expectedUriString = UnitTestsConstants.WykopHostUrl + "Profile/Index/" + 
                                       systemUnderTest.ProfileUsername + "/" +
                                      "appkey," + UnitTestsConstants.AppKey;
            ExpectedRequestUri = new Uri(expectedUriString);
        }


    }
}