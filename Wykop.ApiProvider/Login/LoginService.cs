using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RestSharp.Portable;
using RestSharp.Portable.Serializers;
using Wykop.ApiProvider.Common;
using Wykop.ApiProvider.Common.Constants;
using Wykop.ApiProvider.Common.Extensions;
using Wykop.ApiProvider.Data;

namespace Wykop.ApiProvider.Login
{
    public class LoginService : ILoginService
    {
        private readonly IApiDataContainer _dataContainer;
        private readonly RestClient _restClient;

        public LoginService(IApiDataContainer dataContainer)
        {
            _dataContainer = dataContainer;
            _restClient = new RestClient(ApiConstants.HostUrl);
            _restClient.IgnoreResponseStatusCode = true;
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
            throw new NotImplementedException("not implemented yet.");

            string resourceUrl = ApiConstants.UserResourceName + "/login/appkey," + WykopApiConfiguration.ApiKey + "/";
            var loginRequest = new RestRequest(resourceUrl, HttpMethod.Post);

            dynamic response = await _restClient.Execute<object>(loginRequest, cancellationToken);

            var responseError = response.Data;

            return LoginResult.Successful;
        }
    }
}