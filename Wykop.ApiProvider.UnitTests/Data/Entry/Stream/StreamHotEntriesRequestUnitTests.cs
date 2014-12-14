using System;
using NUnit.Framework;
using Wykop.ApiProvider.Data.Entry.Stream;
using Wykop.ApiProvider.UnitTests.Common;

namespace Wykop.ApiProvider.UnitTests.Data.Entry.Stream
{
    [TestFixture]
    public class StreamHotEntriesRequestUnitTests : WykopRequestBaseTestFixture
    {
        /* Method Parameters: none
         * API Parameters:
               appkey – klucz aplikacji
               page – strona
         * POST Parameters: none
         */

        private int requestedPage = 3;
        private StreamHotEntriesRequest systemUnderTest;

        [SetUp]
        public void SetupUnitTests()
        {
            systemUnderTest = new StreamHotEntriesRequest() {RequestedPage = requestedPage};

            ExpectedRequestUri = new Uri("http://a.wykop.pl/Stream/Hot/appkey," + UnitTestsConstants.AppKey + ",page," + 
                                        requestedPage);
            WykopRequest = systemUnderTest;
        }

        [Test]
        public void BuildRestRequest_PostBodyShouldBeEmpty()
        {
            systemUnderTest.BuildRestRequest().AssertThatRequestHasEmptyPostBody();
        }
    }
}