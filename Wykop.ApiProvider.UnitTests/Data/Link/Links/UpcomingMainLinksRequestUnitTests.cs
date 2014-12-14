using System;
using NUnit.Framework;
using Wykop.ApiProvider.Data.LinkRequest.Links;
using Wykop.ApiProvider.Data.Types;
using Wykop.ApiProvider.UnitTests.Common;

namespace Wykop.ApiProvider.UnitTests.Data.Link.Links
{
    [TestFixture]
    public class UpcomingMainLinksRequestUnitTests : WykopRequestBaseTestFixture
    {
        /* Method Parameters: none
         * API Parameters:
               appkey – klucz aplikacji
               page – strona
               sort – day (ostatnie 24 godz), week (ostatnie 7 dni), month (ostatnie 30 dni)
         * POST Parameters: none
         */

        private const int requestedPage = 3;
        private readonly SortType sortType = SortType.CreateSortByMonth();
        private UpcomingMainLinksRequest systemUnderTest;

        [SetUp]
        public void SetupTests()
        {
            systemUnderTest = new UpcomingMainLinksRequest()
            {
                RequestedPage = requestedPage,
                SortType = sortType
            };

            WykopRequest = systemUnderTest;
            ExpectedRequestUri = new Uri("http://a.wykop.pl/Links/Upcoming/appkey," + UnitTestsConstants.AppKey + 
                                        ",page,3,sort,month");
        }

        [Test]
        public void BuildRestRequest_ShouldHaveEmptyPostBody()
        {
            systemUnderTest.BuildRestRequest().AssertThatRequestHasEmptyPostBody();
        }
    }
}