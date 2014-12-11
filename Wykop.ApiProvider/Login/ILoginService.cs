using System.Threading;
using System.Threading.Tasks;
using Wykop.ApiProvider.Data;

namespace Wykop.ApiProvider.Login
{
    public interface ILoginService
    {
        Task<bool> IsLoggedIn();
        Task<string> GetLoggedUserKey();
        Task<bool> SignIn(LoginData loginData, CancellationToken cancellationToken);
    }
}