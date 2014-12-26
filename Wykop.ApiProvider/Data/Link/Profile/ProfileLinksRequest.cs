using Wykop.ApiProvider.Data.Exceptions;
using Wykop.ApiProvider.Data.LinkRequest;

namespace Wykop.ApiProvider.Data.Link.Profile
{
    public abstract class ProfileLinksRequest : LinksRequest
    {
        public string ProfileUsername { get; private set; }

        protected ProfileLinksRequest(string userName)
        {
            ProfileUsername = userName;
        }

        internal override string GetResourceTypeName()
        {
            return "Profile";
        }

        protected override void BuildParameters()
        {
            base.BuildParameters();
            AddMethodParameters();
        }

        private void AddMethodParameters()
        {
            if (string.IsNullOrEmpty(ProfileUsername))
                throw new RequestCouldNotBeBuildException("Can't build request - ProfileUsername is empty/null.");

            var profileUsernameParameter = new MethodParameter()
            {
                Value = ProfileUsername
            };
            AddMethodParameterToRequest(profileUsernameParameter);
        }
    }
}