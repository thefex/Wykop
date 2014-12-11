using System;

namespace Wykop.ApiProvider.Data.LinkRequest.User
{
    internal class UserFavoritesLinksRequest : UserLinksRequest
    {
        public UserFavoritesLinksRequest(string userName) : base(userName)
        {
        }

        internal override string GetResourceMethodName()
        {
            throw new NotImplementedException();
        }

        protected override void BuildParameters()
        {
            base.BuildParameters();


        }
    }
}