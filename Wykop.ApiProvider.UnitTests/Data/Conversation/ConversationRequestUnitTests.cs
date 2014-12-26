using System;
using System.Net.Http;
using NUnit.Framework;
using Wykop.ApiProvider.Data.Exceptions;
using Wykop.ApiProvider.Data.PMMessage.PM;

namespace Wykop.ApiProvider.UnitTests.Data.Conversation
{
    [TestFixture]
    public class ConversationRequestUnitTests : WykopRequestBaseTestFixture
    {
        private ConversationsRequest systemUnderTest;
        private readonly string mockedUserKey = "testUserkey";

        [SetUp]
        public void Setup()
        {
            systemUnderTest = new ConversationsRequest(mockedUserKey)
            {
                RequestedUsername = "testUsername",
            };

            string expectedUriString = UnitTestsConstants.WykopHostUrl + "PM/Conversation/" +
                                       systemUnderTest.RequestedUsername + "/userkey," + mockedUserKey +
                                       ",appkey," + UnitTestsConstants.AppKey;

            ExpectedRequestUri = new Uri(expectedUriString);
            WykopRequest = systemUnderTest;
        }

        [Test]
        public void BuildRestRequest_WhenUserKeyIsNullOrEmpty_ThenRequestCouldNotBeBuildExceptionShouldBeThrown()
        {
            Assert.Throws<RequestCouldNotBeBuildException>(
                () => new ConversationsRequest(string.Empty).BuildRestRequest()
                );
        }

        [Test]
        public void BuildRestRequest_WhenRequestedUserIsNullOrEmpty_ThenRequestCouldNotBeBuildExceptionShouldBeThrown()
        {
            var sut = new ConversationsRequest(mockedUserKey);

            Assert.Throws<RequestCouldNotBeBuildException>(() => sut.BuildRestRequest());
        }

        [Test]
        public void BuildRestRequest_RequestShouldBeMadeByGetHttpMethod()
        {
            Assert.AreEqual(HttpMethod.Get, systemUnderTest.BuildRestRequest().Method);
        }
    }
}