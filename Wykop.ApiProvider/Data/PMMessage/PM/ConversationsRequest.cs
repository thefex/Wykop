using Wykop.ApiProvider.Data.Exceptions;
using Wykop.ApiProvider.Data.LinkRequest.Helpers;
using Wykop.ApiProvider.Model;

namespace Wykop.ApiProvider.Data.PMMessage.PM
{
    public class ConversationsRequest : WykopRequestBase
    {
        private readonly string _mockedUserKey;

        public ConversationsRequest(string mockedUserKey)
        {
            _mockedUserKey = mockedUserKey;
        }

        public ConversationsRequest(LoggedUser loggedUser)
            : this(loggedUser.UserKey)
        {
        }

        public string RequestedUsername { get; set; }

        internal override string GetResourceTypeName()
        {
            return "PM";
        }

        internal override string GetResourceMethodName()
        {
            return "Conversation";
        }

        protected override void BuildParameters()
        {
            base.BuildParameters();

            if (!IsUserKeyProvided())
                throw new RequestCouldNotBeBuildException("Missing user key - cant build request.");

            if (!IsRequestedUsernameProvided())
                throw new RequestCouldNotBeBuildException("Missing requested username property - can't build request.");

            AddMethodParameterToRequest(new MethodParameter()
            {
                MethodName = "param1",
                Value = RequestedUsername
            });

            AddApiParameterToRequest(ApiParameterProvider.GetUserKeyParameter(_mockedUserKey));
            AddApiParameterToRequest(ApiParameterProvider.GetApplicationKeyParameter());
        }

        private bool IsUserKeyProvided()
        {
            return !string.IsNullOrEmpty(_mockedUserKey);
        }

        private bool IsRequestedUsernameProvided()
        {
            return !string.IsNullOrEmpty(RequestedUsername);
        }
    }
}