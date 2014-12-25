using Wykop.ApiProvider.Data.LinkRequest.Helpers;
using Wykop.ApiProvider.Model;

namespace Wykop.ApiProvider.Data.ConversationList.PM
{
    public class ConversationListRequest : WykopRequestBase
    {
        private readonly string _userKey;

        public ConversationListRequest(string userKey)
        {
            _userKey = userKey;
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

            AddApiParameterToRequest(ApiParameterProvider.GetUserKeyParameter(_userKey));
            AddApiParameterToRequest(ApiParameterProvider.GetApplicationKeyParameter());
        }
    }
}