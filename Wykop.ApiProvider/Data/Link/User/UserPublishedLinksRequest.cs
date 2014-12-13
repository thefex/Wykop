using Wykop.ApiProvider.Data.LinkRequest.Helpers;

namespace Wykop.ApiProvider.Data.LinkRequest.User
{
    public class UserPublishedLinksRequest : UserLinksRequest
    {
        public UserPublishedLinksRequest(string userName) : base(userName)
        {

        }

        public int RequestedPage { get; private set; }

        internal override string GetResourceMethodName()
        {
            return "Published";
        }

        protected override void BuildParameters()
        {
            base.BuildParameters();

            //var pageParameter = ApiParameterProvider.GetPageParameter(RequestedPage);
            //AddParameterToRequest(pageParameter);
        }
    }
}