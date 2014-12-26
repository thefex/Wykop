using System;
using Wykop.ApiProvider.Data.LinkRequest.Helpers;

namespace Wykop.ApiProvider.Data.Link.Profile
{
    public class ProfileFavoritesLinksRequest : ProfileLinksRequest
    {
        public ProfileFavoritesLinksRequest(string userName) : base(userName)
        {
        }

        internal override string GetResourceMethodName()
        {
            return "Favorites";
        }

        public int RequestedListId { get; set; }
        public int RequestedPage { get; set; }

        protected override void BuildParameters()
        {
            base.BuildParameters();

            AddMethodParameterToRequest(new MethodParameter()
            {
                Value = RequestedListId.ToString()
            });

            AddApiParameterToRequest(ApiParameterProvider.GetApplicationKeyParameter());
            AddApiParameterToRequest(ApiParameterProvider.GetPageParameter(RequestedPage));
        }

    }
}