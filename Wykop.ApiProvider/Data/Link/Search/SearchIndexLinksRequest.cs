using System;
using Wykop.ApiProvider.Data.LinkRequest.Helpers;

namespace Wykop.ApiProvider.Data.LinkRequest.Search
{
    public class SearchIndexLinksRequest : BaseSearchLinksRequest
    {
        public int RequestedPage { get; set; }
        public string SearchQuery { get; set; }


        public DateTime SearchStartDate { get; set; }
        public DateTime SearchEndDate { get; set; }
        public int MinimalVotesCount { get; set; }

        internal override string GetResourceMethodName()
        {
            return "Index";
        }

        protected override void BuildParameters()
        {
            base.BuildParameters();

            //var pageParameter = ApiParameterProvider.GetPageParameter(RequestedPage);
            //AddParameterToRequest(pageParameter);

            var searchQuery = PostParameterProvider.GetSearchQueryParameter(SearchQuery);
            AddParameterToRequest(searchQuery);
        }
    }
}