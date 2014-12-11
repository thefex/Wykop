using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Wykop.ApiProvider.Login;
using Wykop.Commands;

namespace Wykop.ViewModel
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly LoginService _loginService;
        private readonly LoginCommand _loginCommand;

        public MainPageViewModel(LoginService loginService)
        {
            _loginService = loginService;
          //  _loginCommand = new LoginCommand(loginService, );

            LoginCommand = new RelayCommand(async () => {});
        }


        public RelayCommand LoginCommand { get; private set; }
    }
}