using Wykop.ApiProvider.Data.LinkRequest.Helpers;

namespace Wykop.ApiProvider.Data.Link.Profile
{
    public class ProfileAddedLinksRequest : ProfileLinksRequest
    {
        public ProfileAddedLinksRequest(string userName) : base(userName)
        {

        }

        public int RequestedPage { get; set; }

        internal override string GetResourceMethodName()
        {
            return "Added";
        }

        protected override void BuildParameters()
        {
            base.BuildParameters();

            AddApiParameterToRequest(ApiParameterProvider.GetApplicationKeyParameter());
            AddApiParameterToRequest(ApiParameterProvider.GetPageParameter(RequestedPage));
        }
    }
}