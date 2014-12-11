using System;
using Wykop.ApiProvider.Data.LinkRequest.Helpers;

namespace Wykop.ApiProvider.Data.LinkRequest.User
{
    internal class UserDiggedLinksRequest : UserLinksRequest
    {
        public UserDiggedLinksRequest(string userName) : base(userName)
        {
            var pageParameter = ApiParameterProvider.GetPageParameter(RequestedPage);

        }

        public int RequestedPage { get; set; }

        internal override string GetResourceTypeName()
        {
            throw new NotImplementedException();
        }

        internal override string GetResourceMethodName()
        {
            throw new NotImplementedException();
        }
    }
}