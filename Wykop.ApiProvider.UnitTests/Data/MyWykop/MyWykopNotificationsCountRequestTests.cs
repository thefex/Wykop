using System;
using NUnit.Framework;
using Wykop.ApiProvider.Data.MyWykop;
using Wykop.ApiProvider.Model;
using Wykop.ApiProvider.UnitTests.Common;

namespace Wykop.ApiProvider.UnitTests.Data.MyWykop
{
    [TestFixture]
    public class MyWykopNotificationsCountRequestTests : WykopRequestBaseTestFixture
    {
        /* Method Parameters: none
         * API Parameters:
               userkey - klucz użytkownika
               appkey – klucz aplikacji
         * POST Parameters: none
         */

        private LoggedUser mockedLoggedUser;
        private readonly string mockedUserKey = "testUserKey";

        [SetUp]
        public void SetupUnitTests()
        {
            mockedLoggedUser = new LoggedUser
            {
                UserKey = mockedUserKey
            };

            var expectedUriString = "http://a.wykop.pl/MyWykop/NotificationsCount/";
            expectedUriString += "userkey," + mockedUserKey;
            expectedUriString += ",appkey," + UnitTestsConstants.AppKey;

            ExpectedRequestUri = new Uri(expectedUriString);
            WykopRequest = new MyWykopNotificationsCountRequest(mockedLoggedUser);
        }

        [Test]
        public void BuildRequest_PostBodyShouldBeEmpty()
        {
            WykopRequest.BuildRestRequest().AssertThatRequestHasEmptyPostBody();
        }
    }
}