using Wykop.ApiProvider.Data.Exceptions;
using Wykop.ApiProvider.Data.LinkRequest.Helpers;

namespace Wykop.ApiProvider.Data.Link.Profile
{
    public class ProfileBuriedLinksRequest : ProfileLinksRequest
    {
        public ProfileBuriedLinksRequest(string userName, string userKey) : base(userName)
        {
            UserKey = userKey;
        }

        public string UserKey { get; private set; }
        public int RequestedPage { get; set; }

        internal override string GetResourceMethodName()
        {
            return "Buried";
        }

        protected override void BuildParameters()
        {
            base.BuildParameters();

            if (string.IsNullOrEmpty(UserKey))
                throw new RequestCouldNotBeBuildException("You cant request for profile buries without UserKey...");

            AddApiParameterToRequest(ApiParameterProvider.GetUserKeyParameter(UserKey));
            AddApiParameterToRequest(ApiParameterProvider.GetApplicationKeyParameter());
            AddApiParameterToRequest(ApiParameterProvider.GetPageParameter(RequestedPage));
        }
    }
}