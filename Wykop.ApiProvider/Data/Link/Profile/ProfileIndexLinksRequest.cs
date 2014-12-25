using Wykop.ApiProvider.Data.Exceptions;
using Wykop.ApiProvider.Data.LinkRequest.Helpers;

namespace Wykop.ApiProvider.Data.Link.Profile
{
    public class ProfileIndexLinksRequest : ProfileLinksRequest
    {
        public ProfileIndexLinksRequest(string userName)
            : base(userName)
        {
        }

        internal override string GetResourceMethodName()
        {
            return "Index";
        }

        protected override void BuildParameters()
        {
            base.BuildParameters();
            AddApiParameters();
        }

        private void AddApiParameters()
        {
            var applicationKeyParameter = ApiParameterProvider.GetApplicationKeyParameter();
            AddApiParameterToRequest(applicationKeyParameter);
        }
    }
}