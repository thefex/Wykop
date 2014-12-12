using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Wykop.ApiProvider.Data;
using Wykop.ApiProvider.Login;

namespace Wykop.Commands
{
    public class LoginCommand
    {
        private readonly ILoginService _loginService;
        private readonly Func<Task> _onLoggedIn;

        public LoginCommand(ILoginService loginService, Func<Task> onLoggedIn)
        {
            _loginService = loginService;
            _onLoggedIn = onLoggedIn;
        }

        public async Task Execute(LoginData loginData, CancellationToken cancellationToken)
        {
            var loginResult = await _loginService.SignIn(loginData, cancellationToken);

            if (loginResult == LoginResult.Successful)
                await _onLoggedIn();
        }
    }
}