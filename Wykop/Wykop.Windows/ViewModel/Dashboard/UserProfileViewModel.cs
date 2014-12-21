using System.Threading.Tasks;
using Microsoft.Xaml.Interactivity;
using Wykop.ApiProvider.Data.Types;
using Wykop.ApiProvider.Login;
using Wykop.ApiProvider.Model;
using Wykop.Common;
using Wykop.View;

namespace Wykop.ViewModel.Dashboard
{
    public class UserProfileViewModel : BaseViewModel
    {
        private const int MinimalUpdateTimeMs = 20*1000; // 20 sec
        private const int MaximalUpdateTImeMs = 90*1000; // 90 sec

        private readonly ILoginService _loginService;
        private readonly DynamicTimeAdjustedDispatcherTimer _timer;

        public UserProfileViewModel(ILoginService loginService, ViewServices viewServices) : base(viewServices)
        {
            var timeTickInterval = new TimeInterval(MinimalUpdateTimeMs, MaximalUpdateTImeMs);
            _timer = new DynamicTimeAdjustedDispatcherTimer(timeTickInterval, UpdateNotificationCount);
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
                await UpdateNotificationCount();
                _timer.Start();
            }
        }

        public override Task Unload()
        {
            _timer.Stop();
            return base.Unload();
        }

        private async Task UpdateNotificationCount()
        {
            if (IsUserLogged)
            {
                int messageCountBeforeUpdate = PrivateMessageNotificationCount;

                HashTagsNotificationCount =
                    await LoggedUserProfile.GetNotificationCount(NotificationType.HashTag, CurrentCancellationToken);
                PrivateMessageNotificationCount =
                    await LoggedUserProfile.GetNotificationCount(NotificationType.PrivateMessage, CurrentCancellationToken);

                if (HasPrivateMessageNotificationCountChanged(messageCountBeforeUpdate, PrivateMessageNotificationCount))
                    _timer.DecreaseTickLength();
                else
                   _timer.IncreaseTickLength();
            }
        }

        private bool HasPrivateMessageNotificationCountChanged(int oldNotificationCount, int newNotifiactionCount)
        {
            return oldNotificationCount != newNotifiactionCount && newNotifiactionCount > 0;
        }
    }
}