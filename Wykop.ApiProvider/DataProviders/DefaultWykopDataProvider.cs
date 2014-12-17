using System.Threading;
using System.Threading.Tasks;
using RestSharp.Portable;
using Wykop.ApiProvider.Common.Constants;
using Wykop.ApiProvider.Data;

namespace Wykop.ApiProvider.DataProviders
{
    public class DefaultWykopDataProvider : IWykopDataProvider
    {
        private readonly RestClient _restClient;

        public DefaultWykopDataProvider()
        {
            _restClient = new RestClient(ApiConstants.HostUrl);
        }

        public async Task<TResult> GetData<TRequest, TResult>(TRequest fromRequest, CancellationToken cancellationToken)
            where TRequest : WykopRequestBase
        {
            // TODO: Error handling
            var restDataRequest = fromRequest.BuildRestRequest();
            var requestResults = await _restClient.Execute<TResult>(restDataRequest, cancellationToken).ConfigureAwait(false);

            return requestResults.Data;
        }
    }
}