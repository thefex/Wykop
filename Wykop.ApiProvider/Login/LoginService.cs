using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using RestSharp.Portable;
using Wykop.ApiProvider.Common.Constants;
using Wykop.ApiProvider.Common.Extensions;
using Wykop.ApiProvider.Data;
using Wykop.ApiProvider.Exceptions;

namespace Wykop.ApiProvider.Login
{
    public class LoginService
    {
        private readonly IApiDataContainer _dataContainer;
        private readonly RestClient _restClient;

        public LoginService(IApiDataContainer dataContainer)
        {
            _dataContainer = dataContainer;
            _restClient = new RestClient(ApiConstants.HostUrl);
        }

        public async Task<bool> IsLoggedIn()
        {
            var userKey = await _dataContainer.Retrieve(DataConstants.UserKey);

            return !string.IsNullOrEmpty(userKey);
        }

        public async Task<string> GetLoggedUserKey()
        {
            return await _dataContainer.Retrieve(DataConstants.UserKey);
        }

        public async Task<bool> SignIn(LoginData loginData, CancellationToken cancellationToken)
        {
            var loginRequest = new RestRequest(ApiConstants.UserResourceName, HttpMethod.Post);
            loginRequest.SignWykopRequest();

            loginRequest.AddBody(new
            {
                login = loginData.Username,
                password = loginData.Password
            });

            var response = await _restClient.Execute(loginRequest, cancellationToken);

            return true;
        }
    }
}