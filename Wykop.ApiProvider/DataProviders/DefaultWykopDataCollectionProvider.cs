using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RestSharp.Portable;
using Wykop.ApiProvider.Common.Constants;
using Wykop.ApiProvider.Data;

namespace Wykop.ApiProvider.DataProviders
{
    public class DefaultWykopDataCollectionProvider<TRequest, TResult> : IWykopDataCollectionProvider<TRequest, TResult>
        where TRequest : WykopRequestBase
    {
        private readonly RestClient _restClient;

        public DefaultWykopDataCollectionProvider()
        {
            _restClient = new RestClient(ApiConstants.HostUrl);
        }

        public async Task<IEnumerable<TResult>> GetDataCollection(TRequest fromRequest,
            CancellationToken cancellationToken)
        {
            var restDataRequest = fromRequest.BuildRestRequest();
            var requestResults = await _restClient.Execute<List<TResult>>(restDataRequest, cancellationToken).ConfigureAwait(false);

            return requestResults.Data;
        }
    }
}