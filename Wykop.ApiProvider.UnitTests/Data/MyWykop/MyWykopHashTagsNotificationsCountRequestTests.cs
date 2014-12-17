using System;
using NUnit.Framework;
using Wykop.ApiProvider.Data.MyWykop;
using Wykop.ApiProvider.UnitTests.Common;

namespace Wykop.ApiProvider.UnitTests.Data.MyWykop
{
    [TestFixture]
    public class MyWykopHashTagsNotificationsCountRequestTests : WykopRequestBaseTestFixture
    {
        /* Method Parameters: none
         * API Parameters:
               userkey - klucz użytkownika
               appkey – klucz aplikacji
         * POST Parameters: none
         */

        private readonly string mockedUserKey = "userKeyTestBlaBla";
        private MyWykopHashTagsNotificationsCountRequest systemUnderTest;

        [SetUp]
        public void SetupTests()
        {
            systemUnderTest = new MyWykopHashTagsNotificationsCountRequest(mockedUserKey);

            var expectedUriString = "http://a.wykop.pl/MyWykop/HashTagsNotificationsCount/";
            expectedUriString += "userkey," + mockedUserKey;
            expectedUriString += ",appkey," + UnitTestsConstants.AppKey;

            ExpectedRequestUri = new Uri(expectedUriString);
            WykopRequest = systemUnderTest;
        }

        [Test]
        public void BuildRestRequest_PostBodyShouldBeEmpty()
        {
            systemUnderTest.BuildRestRequest().AssertThatRequestHasEmptyPostBody();
        }
    }
}