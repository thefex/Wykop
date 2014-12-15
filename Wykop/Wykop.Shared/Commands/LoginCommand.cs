using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Views;
using Wykop.ApiProvider.Data;
using Wykop.ApiProvider.Login;

namespace Wykop.Commands
{
    public class LoginCommand
    {
        private readonly ILoginService _loginService;
        private readonly IDialogService _dialogService;
        private readonly Func<Task> _onLoggedIn;

        public LoginCommand(ILoginService loginService, IDialogService dialogService, Func<Task> onLoggedIn)
        {
            _loginService = loginService;
            _dialogService = dialogService;
            _onLoggedIn = onLoggedIn;
        }

        public async Task Execute(LoginData loginData, CancellationToken cancellationToken)
        {
            var loginResult = await _loginService.SignIn(loginData, cancellationToken);

            if (loginResult == LoginResult.Successful)
                await _onLoggedIn();
            else if (loginResult == LoginResult.InvalidLoginData)
                await _dialogService.ShowError("Nie poprawne dane logowania.", "Błąd :(", "Ok trudno", () => { });
        }
    }
}