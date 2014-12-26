using System;
using System.Threading;
using System.Threading.Tasks;
using RestSharp.Portable;
using Wykop.ApiProvider.Common.Constants;
using Wykop.ApiProvider.DataCreators.Requests.PM;
using Wykop.ApiProvider.Login;
using Wykop.ApiProvider.Model.Operations;

namespace Wykop.ApiProvider.DataCreators
{
    public class PrivateMessageSender : IPrivateMessageSender
    {
        private readonly ILoginService _loginService;
        private readonly RestClient _restClient;

        public PrivateMessageSender(ILoginService loginService)
        {
            _loginService = loginService;
            _restClient = new RestClient(ApiConstants.HostUrl);
        }

        public async Task<PrivateMessageSendResult> SendMessage(PrivateMessageContent messageContent,
            CancellationToken cancellationToken)
        {
            var loggedUser = await _loginService.GetLoggedUser();

            // todo: error handling
            var sendMessageWykopRequest = new SendMessageWykopRequest(messageContent);
            sendMessageWykopRequest.AuthorizeRequest(loggedUser.UserKey);

            RestRequest restSendMessageRequest = sendMessageWykopRequest.BuildRestRequest();
            dynamic results = await _restClient.Execute<object>(restSendMessageRequest, cancellationToken);

            if (results == "true")
                return PrivateMessageSendResult.Sended;

            throw new NotImplementedException("error handling not implemented yet @ private message sender");
        }
    }
}