using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using RestSharp.Portable.Deserializers;
using Wykop.ApiProvider.DataProviders;
using Wykop.ApiProvider.DataProviders.Interfaces;
using Wykop.ApiProvider.Login;
using Wykop.ApiProvider.Model.Extensions;
using Wykop.ApiProvider.Model.MessagesRelated;
using Wykop.Common;
using Wykop.View;

namespace Wykop.ViewModel
{
    public class ConversationViewModel : BaseViewModel
    {
        private readonly IUserWykopDataProvider _userWykopDataProvider;

        public ConversationViewModel(IUserWykopDataProvider userWykopDataProvider, ViewServices viewServices) : base(viewServices)
        {
            _userWykopDataProvider = userWykopDataProvider;

            ConversationMessages = new List<PrivateMessage>();
        }

        public IList<PrivateMessage> ConversationMessages { get; private set; }

        public async Task LoadConverstation(ConversationList fromConversationList)
        {
            ConversationMessages =
                await fromConversationList.GetAllMessages(_userWykopDataProvider, CurrentCancellationToken);
        }
    }
}
