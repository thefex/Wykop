using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Wykop.ApiProvider.Data.LinkRequest;
using Wykop.ApiProvider.Model;

namespace Wykop.ApiProvider.Links
{
    public interface ILinksProvider
    {
        Task<IEnumerable<Link>> GetLinks(LinksRequest linksRequest, CancellationToken cancellationToken);
    }
}