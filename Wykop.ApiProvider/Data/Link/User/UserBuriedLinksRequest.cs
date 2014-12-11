namespace Wykop.ApiProvider.Data.LinkRequest.User
{
    internal class UserBuriedLinksRequest : UserLinksRequest
    {
        private static readonly string BuriedMethodName = "Buried";

        public UserBuriedLinksRequest(string userName) : base(userName)
        {
        }

        internal override string GetResourceMethodName()
        {
            return BuriedMethodName;
        }
    }
}