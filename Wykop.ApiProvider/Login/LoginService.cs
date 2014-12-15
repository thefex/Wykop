using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using RestSharp.Portable;
using RestSharp.Portable.Deserializers;
using Wykop.ApiProvider.Common;
using Wykop.ApiProvider.Common.Constants;
using Wykop.ApiProvider.Common.Extensions;
using Wykop.ApiProvider.Data;
using Wykop.ApiProvider.Model.Internal;

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
            var userKey = await _dataContainer.Retrieve(DataConstants.UserKey);

            return !string.IsNullOrEmpty(userKey);
        }

        public async Task<string> GetLoggedUserKey()
        {
            return await _dataContainer.Retrieve(DataConstants.UserKey);
        }

        public async Task<LoginResult> SignIn(LoginData loginData, CancellationToken cancellationToken)
        {
            bool isApplicationConnected = await _userApplicationKeyProvider.ConnectToApplication(loginData);

            if (!isApplicationConnected)
                return LoginResult.InvalidLoginData;

            var loginRequest = await CreateUserLoginRequest();
            var response = await _restClient.Execute<UserLogin>(loginRequest, cancellationToken);
            await _dataContainer.Save(DataConstants.UserKey, response.Data.UserKey);

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