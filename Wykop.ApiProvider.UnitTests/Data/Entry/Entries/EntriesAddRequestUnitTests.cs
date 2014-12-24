using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.Vpn;
using NUnit.Framework;
using RestSharp.Portable;
using Wykop.ApiProvider.Data.Entry.Entries;
using Wykop.ApiProvider.Data.Exceptions;

namespace Wykop.ApiProvider.UnitTests.Data.Entry.Entries
{
    [TestFixture]
    public class EntriesAddRequestUnitTests : WykopRequestBaseTestFixture
    {
        /* Method Parameters: none
         * API Parameters:
               userkey – klucz użytkownika
               appkey – klucz aplikacji
         * POST Parameters: 
               body - treść wpisu
               embed - url do pliku graficznego lub filmu osadzonego w serwisie hostującym Wideo
         * FILE:
         *     embed - plik graficzny który ma być osadzony w obiekcie (parametr nadpisuje url)
         */

        private readonly string fakeUserKey = "userKey";
        private readonly string fakeBody = "this is body bla bla";
        private readonly Uri fakeMediaUri = new Uri("http://www.unittests.com"); 
        private EntriesAddRequest systemUnderTest;

        [SetUp]
        public void SetupTests()
        {
            systemUnderTest = new EntriesAddRequest()
            {
                UserKey = fakeUserKey,
                Body = fakeBody,
                EmbeddedMediaUri = fakeMediaUri
            };

            ExpectedRequestUri = new Uri("http://a.wykop.pl/Entries/Add/userkey," + fakeUserKey + ",appkey," +
                                        UnitTestsConstants.AppKey);
            WykopRequest = systemUnderTest;
        }

        [Test]
        public void BuildRequest_FieldsAreFilled_BodyAndMediaUriShouldBeEmbeddedInPost()
        {
            var restRequest = systemUnderTest.BuildRestRequest();
            var postBodyParameters = restRequest.Parameters.Where(x => x.Type == ParameterType.RequestBody).ToList();

            Assert.AreEqual(postBodyParameters.Count, 2);

            var bodyParameter = postBodyParameters[0];
            Assert.AreEqual(bodyParameter.Name, "body");
            Assert.AreEqual(bodyParameter.Value, systemUnderTest.Body);

            var mediaParameter = postBodyParameters[1];
            Assert.AreEqual(mediaParameter.Name, "embed");
            Assert.AreEqual(mediaParameter.Value, systemUnderTest.EmbeddedMediaUri.OriginalString);
        }

        [Test]
        public void BuildRequest_UserKeyIsMissing_RequestCouldNotBeBuildExceptionShouldBeThrown()
        {
            var sut = new EntriesAddRequest();
            Assert.Throws<RequestCouldNotBeBuildException>(() => sut.BuildRestRequest());
        }
    }
}
