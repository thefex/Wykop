using System.Threading;
using System.Threading.Tasks;
using Wykop.ApiProvider.Data;
using Wykop.ApiProvider.DataProviders.Interfaces;
using Wykop.ApiProvider.Login;

namespace Wykop.ApiProvider.DataProviders
{
    public class LoggedUserWykopDataProvider : IUserWykopDataProvider
    {
        private readonly ILoginService _loginService;
        private readonly IWykopDataProvider _wykopDataProvider;

        public LoggedUserWykopDataProvider(ILoginService loginService, IWykopDataProvider wykopDataProvider)
        {
            _loginService = loginService;
            _wykopDataProvider = wykopDataProvider;
        }

        public Task<TResult> GetData<TRequest, TResult>(TRequest fromRequest, CancellationToken cancellationToken)
            where TRequest : WykopRequestBase
        {
            return _wykopDataProvider.GetData<TRequest, TResult>(fromRequest, cancellationToken);
        }

        /// <summary>
        ///     Get data from request with provided user key.
        /// </summary>
        /// <typeparam name="TRequest">Authorizable Wykop Request Type</typeparam>
        /// <typeparam name="TResult">Result type</typeparam>
        /// <param name="fromRequest">Request to be made to wykop api.</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Returns data provided by WykopApi.</returns>
        public async Task<TResult> GetUserData<TRequest, TResult>(TRequest fromRequest,
            CancellationToken cancellationToken) where TRequest : WykopRequestBase, IAuthorizable
        {
            var loggedUser = await _loginService.GetLoggedUser();
            fromRequest.AuthorizeRequest(loggedUser.UserKey);

            return await GetData<TRequest, TResult>(fromRequest, cancellationToken);
        }
    }
}