using Wykop.ApiProvider.Data.LinkRequest.Helpers;
using Wykop.ApiProvider.Data.Types;

namespace Wykop.ApiProvider.Data.LinkRequest.Links
{
    public abstract class MainLinksRequest : LinksRequest
    {
        public int RequestedPage { get; set; }
        public SortType SortType { get; set; }

        protected MainLinksRequest()
        {
            RequestedPage = 1;
            SortType = SortType.CreateSortByDay();
        }

        internal override string GetResourceTypeName()
        {
            return "Links";
        }

        protected override void BuildParameters()
        {
            base.BuildParameters();

            BuildApiParameters();
        }

        private void BuildApiParameters()
        {
            var appKeyParameter = ApiParameterProvider.GetApplicationKeyParameter();
            var pageParameter = ApiParameterProvider.GetPageParameter(RequestedPage);
            var sortParameter = ApiParameterProvider.GetSortParameter(SortType);

            AddApiParameterToRequest(appKeyParameter);
            AddApiParameterToRequest(pageParameter);
            AddApiParameterToRequest(sortParameter);
        }
    }
}
