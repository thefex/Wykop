using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using PostSharp.Patterns.Model;
using Wykop.ApiProvider.Data;
using Wykop.ApiProvider.Login;
using Wykop.Commands;
using Wykop.Common;
using Wykop.View;

namespace Wykop.ViewModel
{
    public class LoginPageViewModel : BaseViewModel
    {
        private readonly LoginCommand _loginCommand;

        public LoginPageViewModel(ILoginService loginService, ViewServices viewServices)
            : base(viewServices)
        {
            _loginCommand = new LoginCommand(loginService, viewServices.Dialog, () =>
            {
                IsPageLeaveRequested = true;
                return Task.FromResult(true);
            });

            LoginCommand = new RelayCommand(async () => await TryRunAsynchronousOperation(Login));
            SkipLoginCommand = new RelayCommand(() => IsPageLeaveRequested = true);
            TransferToDashboardCommand = new RelayCommand(() => Navigation.NavigateTo(NavigationPageKeys.DashboardPageKey));
        }

        private async Task Login()
        {
            LoginData loginData = new LoginData()
            {
                Username = LoginName,
                Password = Password
            };

            await _loginCommand.Execute(loginData, CurrentCancellationToken);
        }

        public bool IsPageLeaveRequested { get; set; }
        
        public string LoginName { get; set; }
        public string Password { get; set; }

        public RelayCommand SkipLoginCommand { get; private set; }
        public RelayCommand LoginCommand { get; private set; }
        public RelayCommand TransferToDashboardCommand { get; private set; }
    }
}