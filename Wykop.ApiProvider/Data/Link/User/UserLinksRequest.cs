using Wykop.ApiProvider.Data.LinkRequest.Helpers;

namespace Wykop.ApiProvider.Data.LinkRequest.User
{
    public abstract class UserLinksRequest : LinksRequest
    {
        protected UserLinksRequest(string userName)
        {
            Username = userName;
        }

        public string Username { get; private set; }

        internal override string GetResourceTypeName()
        {
            return "profile";
        }

        protected override void BuildParameters()
        {
            base.BuildParameters();

            var usernameParameter = MethodParameterProvider.GetUsernameParameter(Username);
            AddParameterToRequest(usernameParameter);
        }
    }
}