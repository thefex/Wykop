using Wykop.ApiProvider.Data.LinkRequest.Helpers;

namespace Wykop.ApiProvider.Data.LinkRequest.User
{
    public class UserAddedLinksRequest : UserLinksRequest
    {
        private static readonly string AddedLinksMethodName = "Added";

        public UserAddedLinksRequest(string userName) : base(userName)
        {

        }

        internal override string GetResourceMethodName()
        {
            return AddedLinksMethodName;
        }
    }
}