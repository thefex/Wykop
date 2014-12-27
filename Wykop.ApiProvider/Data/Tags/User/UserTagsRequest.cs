using Wykop.ApiProvider.Data.Exceptions;
using Wykop.ApiProvider.Data.LinkRequest.Helpers;

namespace Wykop.ApiProvider.Data.Tags.User
{
    public class UserTagsRequest : TagWykopRequest, IAuthorizable
    {
        private string userKey;

        internal override string GetResourceTypeName()
        {
            return "User";
        }

        internal override string GetResourceMethodName()
        {
            return "Tags";
        }

        protected override void BuildParameters()
        {
            base.BuildParameters();

            if (!IsRequestAuthorized())
                throw new RequestCouldNotBeBuildException("Request is not authorized - missing userkey.");

            AddApiParameterToRequest(ApiParameterProvider.GetUserKeyParameter(userKey));
            AddApiParameterToRequest(ApiParameterProvider.GetApplicationKeyParameter());
        }

        private bool IsRequestAuthorized()
        {
            return !string.IsNullOrEmpty(userKey);
        }

        public void AuthorizeRequest(string userKey)
        {
            this.userKey=userKey;
        }
    }
}