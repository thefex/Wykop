using System;
using System.Linq;
using System.Net.Http;
using Windows.Devices.Sms;
using NUnit.Framework;
using RestSharp.Portable;
using Wykop.ApiProvider.Data.Exceptions;
using Wykop.ApiProvider.DataCreators.Requests.PM;
using Wykop.ApiProvider.Model.Operations;
using Wykop.ApiProvider.UnitTests.Data;

namespace Wykop.ApiProvider.UnitTests.DataCreators
{
    [TestFixture]
    public class SendMessageWykopRequestUnitTests : WykopRequestBaseTestFixture
    {
        private SendMessageWykopRequest systemUnderTest;
        private PrivateMessageContent privateMessageContent;

        [SetUp]
        public void SetupTests()
        {
            privateMessageContent = new PrivateMessageContent("testUsername" , "testBody", new Uri("http://www.test.com"));   
            systemUnderTest = new SendMessageWykopRequest(privateMessageContent);

            string mockedUserkey = "testUserkey";
            systemUnderTest.AuthorizeRequest(mockedUserkey);

            string expectedUriString = UnitTestsConstants.WykopHostUrl + "PM/SendMessage/" +
                                       privateMessageContent.UsernameTarget +
                                       "/userkey," + mockedUserkey + ",appkey," + UnitTestsConstants.AppKey;

            ExpectedRequestUri = new Uri(expectedUriString);
            WykopRequest = systemUnderTest;
        }

        [Test]
        public void BuildRestRequest_AssertThatBodyIsSendedByPost()
        {
            Assert.IsTrue(systemUnderTest.BuildRestRequest().Parameters.Any(x =>
                x.Type == ParameterType.GetOrPost && x.Name == "body" && x.Value == privateMessageContent.Body
                ));
        }

        [Test]
        public void BuildRestRequest_AssertThatEmbeddedUriIsSendedByPost()
        {
            Assert.IsTrue(systemUnderTest.BuildRestRequest().Parameters.Any(x =>
                x.Type == ParameterType.GetOrPost && x.Name == "embed" && x.Value == privateMessageContent.EmbeddedUri.OriginalString
                ));
        }

        [Test]
        public void BuildRestRequest_AssertThatRequestIsSendedByPostHttpMethod()
        {
            Assert.AreEqual(HttpMethod.Post, systemUnderTest.BuildRestRequest().Method);
        }

        [Test]
        public void BuildRestRequest_WhenRequestIsNotAuthorized_RequestCouldNotBeBuildShouldBeThrown()
        {
            Assert.Throws<RequestCouldNotBeBuildException>(() =>
                new SendMessageWykopRequest(privateMessageContent).BuildRestRequest()
                );
        }

        [Test]
        public void BuildRestRequest_WhenTargetUsernameIsNotProvided_RequestCouldNotBeBuildShouldBeThrown()
        {
            Assert.Throws<RequestCouldNotBeBuildException>(() =>
                new SendMessageWykopRequest(new PrivateMessageContent(string.Empty, "testBody")).BuildRestRequest());
        }
    }
}