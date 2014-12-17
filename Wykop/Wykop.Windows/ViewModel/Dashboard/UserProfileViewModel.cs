using System.Threading.Tasks;
using Microsoft.Xaml.Interactivity;
using Wykop.ApiProvider.Data.Types;
using Wykop.ApiProvider.Login;
using Wykop.ApiProvider.Model;
using Wykop.View;

namespace Wykop.ViewModel.Dashboard
{
    public class UserProfileViewModel : BaseViewModel
    {
        private readonly ILoginService _loginService;

        public UserProfileViewModel(ILoginService loginService, ViewServices viewServices) : base(viewServices)
        {
            _loginService = loginService;
        }

        public bool IsUserLogged { get; set; }
        public LoggedUser LoggedUserProfile { get; set; }

        public int HashTagsNotificationCount { get; set; }
        public int PrivateMessageNotificationCount { get; set; }

        public override async Task Load()
        {
            await base.Load();

            IsUserLogged = await _loginService.IsLoggedIn();
            if (IsUserLogged)
            {
                LoggedUserProfile = await _loginService.GetLoggedUser();
                HashTagsNotificationCount = 
                    await LoggedUserProfile.GetNotificationCount(NotificationType.HashTag, CurrentCancellationToken);
                PrivateMessageNotificationCount =
                    await
                        LoggedUserProfile.GetNotificationCount(NotificationType.PrivateMessage, CurrentCancellationToken);
            }
        }
    }
}