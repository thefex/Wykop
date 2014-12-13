using Wykop.ApiProvider.Data.LinkRequest.Helpers;

namespace Wykop.ApiProvider.Data.LinkRequest.User
{
    public class UserCommentedLinksRequest : UserLinksRequest
    {
        public UserCommentedLinksRequest(string userName) : base(userName)
        {
            //var pageParameter = ApiParameterProvider.GetPageParameter(RequestedPage);
            //AddParameterToRequest(pageParameter);
        }

        public int RequestedPage { get; set; }

        internal override string GetResourceMethodName()
        {
            return "Commented";
        }

    }
}