using System;
using NUnit.Framework;
using Wykop.ApiProvider.Data.Entry.Stream;
using Wykop.ApiProvider.UnitTests.Common;

namespace Wykop.ApiProvider.UnitTests.Data.Entry.Stream
{
    [TestFixture]
    public class StreamIndexEntriesRequestUnitTests : WykopRequestBaseTestFixture
    {
        /* Method Parameters: none
         * API Parameters:
               appkey – klucz aplikacji
               page – strona
         * POST Parameters: none
         */

        private int requestedPage = 1;
        private StreamIndexEntriesRequest systemUnderTest;

        [SetUp]
        public void SetupUnitTests()
        {
            systemUnderTest = new StreamIndexEntriesRequest() {RequestedPage = requestedPage};

            ExpectedRequestUri = new Uri("http://a.wykop.pl/Stream/Index/appkey," + UnitTestsConstants.AppKey + ",page," + 
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