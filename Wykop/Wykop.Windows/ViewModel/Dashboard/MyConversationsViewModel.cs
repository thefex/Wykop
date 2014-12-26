using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using Wykop.ApiProvider.DataProviders;
using Wykop.ApiProvider.Login;
using Wykop.ApiProvider.Model.Extensions;
using Wykop.ApiProvider.Model.MessagesRelated;
using Wykop.Common;
using Wykop.View;

namespace Wykop.ViewModel.Dashboard
{
    public class MyConversationsViewModel : BaseViewModel
    {
        private readonly ILoginService _loginService;
        private readonly IWykopDataProvider _dataProvider;

        public MyConversationsViewModel(ILoginService loginService, IWykopDataProvider dataProvider,
            ViewServices viewServices)
            : base(viewServices)
        {
            _loginService = loginService;
            _dataProvider = dataProvider;

            Conversations = Enumerable.Empty<ConversationList>().ToList();

            GoToConversationCommand = new RelayCommand<ConversationList>((conversationList) =>
            {
                // why to json instead of passing object?
                // because if navigation state would be saved then some weird exceptions will be thrown on suspended
                // navigation parameters can be only primitive types - (marking serializable etc doesn't work because 
                // internal winrt serializator is used) Wish it was better documentated.
                string serializedConversation = conversationList.SerializeToJsonString();
                Navigation.NavigateTo(NavigationPageKeys.ConversationPageKey, serializedConversation);
            });
        }

        public RelayCommand<ConversationList> GoToConversationCommand { get; private set; }
        public IList<ConversationList> Conversations { get; private set; }
        public bool AreTagsAvailable { get; set; }

        public override async Task Load()
        {
            await base.Load();
            AreTagsAvailable = await _loginService.IsLoggedIn();

            if (AreTagsAvailable)
                await UpdateConversationsList();
        }

        private async Task UpdateConversationsList()
        {
            var loggedUser = await _loginService.GetLoggedUser();
            Conversations = await loggedUser.GetConversationLists(_dataProvider, CurrentCancellationToken);
        }
    }
}