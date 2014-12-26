using System.Net.Http;
using RestSharp.Portable;
using Wykop.ApiProvider.Data;
using Wykop.ApiProvider.Data.Exceptions;
using Wykop.ApiProvider.Data.LinkRequest.Helpers;
using Wykop.ApiProvider.Model.Operations;

namespace Wykop.ApiProvider.DataCreators.Requests.PM
{
    internal class SendMessageWykopRequest : WykopRequestBase, IAuthorizable
    {
        private string userKey;
        private readonly PrivateMessageContent _privateMessageContent;

        public SendMessageWykopRequest(PrivateMessageContent privateMessageContent)
        {
            _privateMessageContent = privateMessageContent;
            RequestHttpMethod = HttpMethod.Post;
        }

        public void AuthorizeRequest(string userKey)
        {
            this.userKey = userKey;
        }

        internal override string GetResourceTypeName()
        {
            return "PM";
        }

        internal override string GetResourceMethodName()
        {
            return "SendMessage";
        }

        protected override void BuildParameters()
        {
            base.BuildParameters();

            if (!IsRequestAuthorizedWithUserKey())
                throw new RequestCouldNotBeBuildException("Request is not authorized with userkey.");

            if (!_privateMessageContent.IsValidPrivateMessage())
                throw new RequestCouldNotBeBuildException("Provided message is not valid - request can't be build." +
                                                          "Do you provided TargetUsername and (Body or EmbededUri or both)?");

            AddMethodParameterToRequest(new MethodParameter {Value = _privateMessageContent.UsernameTarget});
            AddApiParameters();
            AddPostParameters();
        }

        private void AddApiParameters()
        {
            AddApiParameterToRequest(ApiParameterProvider.GetUserKeyParameter(userKey));
            AddApiParameterToRequest(ApiParameterProvider.GetApplicationKeyParameter());
        }

        private void AddPostParameters()
        {
            var bodyParameter = new Parameter
            {
                Name = "body",
                Value = _privateMessageContent.Body,
                Type = ParameterType.GetOrPost
            };
            AddParameterToRequest(bodyParameter);

            if (_privateMessageContent.EmbeddedUri != null)
            {
                var embeddedUriParameter = new Parameter
                {
                    Name = "embed",
                    Value = _privateMessageContent.EmbeddedUri.OriginalString,
                    Type = ParameterType.GetOrPost
                };

                AddParameterToRequest(embeddedUriParameter);
            }
        }

        private bool IsRequestAuthorizedWithUserKey()
        {
            return !string.IsNullOrEmpty(userKey);
        }
    }
}