using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using RestSharp.Portable;
using Wykop.ApiProvider.Common.Constants;
using Wykop.ApiProvider.Data.LinkRequest;
using Wykop.ApiProvider.Model;

namespace Wykop.ApiProvider.Links
{
    public class LinksProvider : ILinksProvider
    {
        private readonly RestClient _restClient;

        public LinksProvider()
        {
            _restClient = new RestClient(ApiConstants.HostUrl);
        }

        public async Task<IEnumerable<Link>> GetLinks(LinksRequest requestedLinks, CancellationToken cancellationToken)
        {
            var linksRequest = requestedLinks.BuildRestRequest();

            var requestResults = await _restClient.Execute<List<Link>>(linksRequest, cancellationToken).ConfigureAwait(false);

            return requestResults.Data;
        }
    }
}