using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using GalaSoft.MvvmLight.Command;
using RestSharp.Portable.Deserializers;
using Wykop.ApiProvider.DataCreators;
using Wykop.ApiProvider.DataProviders;
using Wykop.ApiProvider.DataProviders.Interfaces;
using Wykop.ApiProvider.Login;
using Wykop.ApiProvider.Model.Extensions;
using Wykop.ApiProvider.Model.MessagesRelated;
using Wykop.ApiProvider.Model.Operations;
using Wykop.Common;
using Wykop.View;

namespace Wykop.ViewModel
{
    public class ConversationViewModel : BaseViewModel
    {
        private readonly IUserWykopDataProvider _userWykopDataProvider;
        private readonly IPrivateMessageSender _messageSender;

        public ConversationViewModel(IUserWykopDataProvider userWykopDataProvider, IPrivateMessageSender messageSender,
                                    ViewServices viewServices) : base(viewServices)
        {
            _userWykopDataProvider = userWykopDataProvider;
            _messageSender = messageSender;

            ConversationMessages = new List<PrivateMessage>();
            SendPrivateMessageCommand = new RelayCommand(async () =>
            {
                var messageContent = new PrivateMessageContent(TargetUsername, NewMessageBody);
                if (!messageContent.IsValidPrivateMessage())
                    await Dialog.ShowError("Zle wyplenione dane", "Dd leszke", "okej", () => { });
                else
                    await _messageSender.SendMessage(messageContent, CurrentCancellationToken);
            });
        }

        public RelayCommand SendPrivateMessageCommand { get; private set; }
        public IList<PrivateMessage> ConversationMessages { get; private set; }

        public string NewMessageBody { get; set; }
        public string TargetUsername { get; private set; }

        public async Task LoadConverstation(ConversationList fromConversationList)
        {
            TargetUsername = fromConversationList.Author;
            ConversationMessages =
                await fromConversationList.GetAllMessages(_userWykopDataProvider, CurrentCancellationToken);
        }
    }
}
