using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using Wykop.ApiProvider.Login;
using Wykop.ApiProvider.Model;
using Wykop.Common;
using Wykop.View;
using Wykop.ViewModel.Dashboard;

namespace Wykop.ViewModel
{
    public class DashboardViewModel : BaseViewModel
    {
        private readonly ILoginService _loginService;

        public DashboardViewModel(ILoginService loginService, ViewServices viewServices) : base(viewServices)
        {
            _loginService = loginService;
            NavigateToMikroblog = new RelayCommand(() => Navigation.NavigateTo(NavigationPageKeys.MikroblogPageKey));
        }

        public HomeDashboardViewModel Home { get; set; }
        public HotDashboardViewModel Hot { get; set; }
        public WykopaliskoDashboardViewModel Wykopalisko { get; set; }
        public UserProfileViewModel UserProfile { get; set; }
        public MyConversationsViewModel Conversations { get; set; }
        public UserObservedTagsViewModel ObservedTags { get; set; }

        public RelayCommand NavigateToMikroblog { get; private set; }
        public bool IsUserLoggedIn { get; private set; }

        public override async Task Load()
        {
            var tasksToExecute = new Task[]
            {
                base.Load(), Home.Load(), Wykopalisko.Load(), Hot.Load(), UserProfile.Load(), Conversations.Load()
            };

            IsUserLoggedIn = await _loginService.IsLoggedIn();
            if (IsUserLoggedIn)
                await NotifyThatUserIsLogged();

            await Task.WhenAll(tasksToExecute);
        }

        private async Task NotifyThatUserIsLogged()
        {
            var loggedUser = await _loginService.GetLoggedUser();
            MessengerInstance.Send(loggedUser, MessengerTokens.DashboardLoggedUserDeliveryToken);
        }
    }
}