using Wykop.ApiProvider.Data.LinkRequest.Helpers;

namespace Wykop.ApiProvider.Data.Link.Profile
{
    public class ProfileDiggedLinksRequest : ProfileLinksRequest
    {
        public ProfileDiggedLinksRequest(string userName) : base(userName)
        {
        }

        public int RequestedPage { get; set; }

        internal override string GetResourceMethodName()
        {
            return "Digged";
        }

        protected override void BuildParameters()
        {
            base.BuildParameters();

            AddApiParameterToRequest(ApiParameterProvider.GetApplicationKeyParameter());
            AddApiParameterToRequest(ApiParameterProvider.GetPageParameter(RequestedPage));
        }
    }
}