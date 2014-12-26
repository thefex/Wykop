using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Wykop.ApiProvider.Data;

namespace Wykop.ApiProvider.DataProviders.Interfaces
{
    public interface IWykopDataCollectionProvider<in TRequest, TResult>
        where TRequest : WykopRequestBase
    {
        Task<IEnumerable<TResult>> GetDataCollection(TRequest fromRequest, CancellationToken cancellationToken);
    }
}