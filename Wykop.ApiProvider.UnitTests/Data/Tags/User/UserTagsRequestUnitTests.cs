using System;
using NUnit.Framework;
using Wykop.ApiProvider.Data.Exceptions;
using Wykop.ApiProvider.Data.Tags.User;

namespace Wykop.ApiProvider.UnitTests.Data.Tags.User
{
    [TestFixture]
    public class UserTagsRequestUnitTests : WykopRequestBaseTestFixture
    {
        private UserTagsRequest systemUnderTest;

        [SetUp]
        public void SetupTests()
        {
            string userKeyMock = "testUserKey";
            systemUnderTest = new UserTagsRequest();
            systemUnderTest.AuthorizeRequest(userKeyMock);

            string expectedUriString = UnitTestsConstants.WykopHostUrl + "User/Tags/userkey," + userKeyMock +
                                       ",appkey," + UnitTestsConstants.AppKey;
            ExpectedRequestUri = new Uri(expectedUriString);
            WykopRequest = systemUnderTest;
        }

        [Test]
        public void BuildRestRequest_WhenRequestIsNotAuthorized_RequestCouldNotBeBuildExceptionShouldBeThrown()
        {
            Assert.Throws<RequestCouldNotBeBuildException>(() => new UserTagsRequest().BuildRestRequest());
        }   
    }
}