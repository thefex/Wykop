using System.Threading;
using System.Threading.Tasks;
using Wykop.ApiProvider.Data;
using Wykop.ApiProvider.Model;

namespace Wykop.ApiProvider.Login
{
    public interface ILoginService
    {
        Task<bool> IsLoggedIn();
        Task<LoggedUser> GetLoggedUser();
        Task<LoginResult> SignIn(LoginData loginData, CancellationToken cancellationToken);
    }
}