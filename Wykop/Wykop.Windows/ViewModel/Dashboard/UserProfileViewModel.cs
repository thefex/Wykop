using System.Threading.Tasks;
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
        public Profile LoggedUserProfile { get; set; }

        public override async Task Load()
        {
            await base.Load();

            IsUserLogged = await _loginService.IsLoggedIn();
            if (IsUserLogged)
                LoggedUserProfile = await _loginService.GetLoggedUser();
        }
    }
}