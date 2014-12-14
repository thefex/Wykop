using System;
using NUnit.Framework;
using Wykop.ApiProvider.Data.LinkRequest.Links;
using Wykop.ApiProvider.Data.Types;
using Wykop.ApiProvider.UnitTests.Common;

namespace Wykop.ApiProvider.UnitTests.Data.Link.Links
{
    [TestFixture]
    public class PromotedMainLinksRequestUnitTests : WykopRequestBaseTestFixture
    {
        /* Method Parameters: none
         * API Parameters:
               appkey – klucz aplikacji
               page – strona
	           sort – day (ostatnie 24 godz), week (ostatnie 7 dni), month (ostatnie 30 dni)
         * POST Parameters: none
         */

        private const int requestedPage = 2;
        private PromotedMainLinksRequest systemUnderTest;
        private readonly SortType sortType = SortType.CreateSortByDay();

        [SetUp]
        public void SetupTests()
        {
            systemUnderTest = new PromotedMainLinksRequest
            {
                RequestedPage = requestedPage,
                SortType = sortType
            };

            ExpectedRequestUri =
                new Uri("http://a.wykop.pl/Links/Promoted/appkey," + UnitTestsConstants.AppKey + ",page,2,sort,day");
            WykopRequest = systemUnderTest;
        }

        [Test]
        public void BuildRestRequest_PostBodyShouldBeEmpty()
        {
            systemUnderTest.BuildRestRequest().AssertThatRequestHasEmptyPostBody();
        }
    }
}