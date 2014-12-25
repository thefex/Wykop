using System;
using NUnit.Framework;
using Wykop.ApiProvider.Data.ConversationList.PM;

namespace Wykop.ApiProvider.UnitTests.Data.ConversationList.PM
{
    [TestFixture]
    public class ConversationListRequestUnitTests : WykopRequestBaseTestFixture
    {
        private ConversationListRequest systemUnderTest;
        private string userKeyMock = "userKeyTests";

        [SetUp]
        public void SetupTests()
        {
            systemUnderTest = new ConversationListRequest(userKeyMock);

            string expectedUriString = UnitTestsConstants.WykopHostUrl + "PM/ConversationsList/userkey," +
                                       userKeyMock + ",appkey," + UnitTestsConstants.AppKey;
            ExpectedRequestUri = new Uri(expectedUriString);
            WykopRequest = systemUnderTest;
        }
    }
}