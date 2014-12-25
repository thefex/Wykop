using Wykop.ApiProvider.Data.LinkRequest.Helpers;

namespace Wykop.ApiProvider.Data.Link.Profile
{
    public class ProfileCommentedLinksRequest : ProfileLinksRequest
    {
        public ProfileCommentedLinksRequest(string userName) : base(userName)
        {
        }

        public int RequestedPage { get; set; }

        internal override string GetResourceMethodName()
        {
            return "Commented";
        }

        protected override void BuildParameters()
        {
            base.BuildParameters();

            AddApiParameterToRequest(ApiParameterProvider.GetApplicationKeyParameter());
            AddApiParameterToRequest(ApiParameterProvider.GetPageParameter(RequestedPage));
        }
    }
}