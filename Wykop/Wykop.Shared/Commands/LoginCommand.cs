using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Wykop.ApiProvider.Data;
using Wykop.ApiProvider.Login;

namespace Wykop.Commands
{
    public class LoginCommand : ICommand
    {
        private readonly CancellationToken _cancellationToken;
        private readonly LoginService _loginService;
        private readonly Func<Task> _onLoggedIn;

        public LoginCommand(LoginService loginService, Func<Task> onLoggedIn, CancellationToken cancellationToken)
        {
            _loginService = loginService;
            _onLoggedIn = onLoggedIn;
            _cancellationToken = cancellationToken;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            var loginData = (LoginData) parameter;

            var loginResult = await _loginService.SignIn(loginData, _cancellationToken);

            if (loginResult)
                await _onLoggedIn();
        }

        public event EventHandler CanExecuteChanged;
    }
}