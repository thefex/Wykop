using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp.Portable;
using Wykop.ApiProvider.Common;
using Wykop.ApiProvider.Common.Constants;
using Wykop.ApiProvider.Common.Extensions;
using Wykop.ApiProvider.Data;
using Wykop.ApiProvider.Model;

namespace Wykop.ApiProvider.Login
{
    public class LoginService : ILoginService
    {
        private readonly IApiDataContainer _dataContainer;
        private readonly UserApplicationKeyProvider _userApplicationKeyProvider;
        private readonly RestClient _restClient;

        public LoginService(IApiDataContainer dataContainer)
        {
            _dataContainer = dataContainer;
            _userApplicationKeyProvider = new UserApplicationKeyProvider(dataContainer);
            _restClient = new RestClient(ApiConstants.HostUrl);
        }

        public async Task<bool> IsLoggedIn()
        {
            var userKey = await _dataContainer.Retrieve(DataConstants.LoggedUserJsonKey).ConfigureAwait(false);
            return !string.IsNullOrEmpty(userKey);
        }

        public async Task<LoggedUser> GetLoggedUser()
        {
            var loggedUserJson = await _dataContainer.Retrieve(DataConstants.LoggedUserJsonKey);
            return JsonConvert.DeserializeObject<LoggedUser>(loggedUserJson);
        }

        public async Task<LoginResult> SignIn(LoginData loginData, CancellationToken cancellationToken)
        {
            bool isApplicationConnected = await _userApplicationKeyProvider.ConnectToApplication(loginData);

            if (!isApplicationConnected)
                return LoginResult.InvalidLoginData;

            // TODO: error handling
            var loginRequest = await CreateUserLoginRequest();
            var response = await _restClient.Execute<LoggedUser>(loginRequest, cancellationToken).ConfigureAwait(false);

            var serializedLoggedUser = JsonConvert.SerializeObject(response.Data);
            await _dataContainer.Save(DataConstants.LoggedUserJsonKey, serializedLoggedUser).ConfigureAwait(false);

            return LoginResult.Successful;
        }

        private async Task<RestRequest> CreateUserLoginRequest()
        {
            var userAccountKey = await _userApplicationKeyProvider.GetConnectedAccountKey();

            var resourceUrl = ApiConstants.UserResourceName + "/login/appkey," + WykopApiConfiguration.ApiKey + "/";
            var loginRequest = new RestRequest(resourceUrl, HttpMethod.Post);
            loginRequest.Parameters.Add(new Parameter()
            {
                Type = ParameterType.GetOrPost,
                Name = "accountkey",
                Value = userAccountKey
            });
            loginRequest.SignWykopRequest();
            return loginRequest;
        }
    }
}