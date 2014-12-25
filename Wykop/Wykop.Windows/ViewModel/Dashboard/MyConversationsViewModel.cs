using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wykop.ApiProvider.DataProviders;
using Wykop.ApiProvider.Login;
using Wykop.ApiProvider.Model.Extensions;
using Wykop.ApiProvider.Model.MessagesRelated;
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
        }

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