using Wykop.ApiProvider.Data.LinkRequest.Helpers;
using Wykop.ApiProvider.Model;

namespace Wykop.ApiProvider.Data.ConversationList.PM
{
    public class ConversationListRequest : WykopRequestBase, IAuthorizable
    {
        private string userKey;

        public ConversationListRequest()
        {
            
        }

        public ConversationListRequest(string userKey)
        {
            this.userKey = userKey;
        }

        public ConversationListRequest(LoggedUser loggedUser)
            : this(loggedUser.UserKey)
        {
        }

        internal override string GetResourceTypeName()
        {
            return "PM";
        }

        internal override string GetResourceMethodName()
        {
            return "ConversationsList";
        }

        protected override void BuildParameters()
        {
            base.BuildParameters();

            AddApiParameterToRequest(ApiParameterProvider.GetUserKeyParameter(userKey));
            AddApiParameterToRequest(ApiParameterProvider.GetApplicationKeyParameter());
        }

        public void AuthorizeRequest(string authorizationUserKey)
        {
            userKey = authorizationUserKey;
        }
    }
}