using System.Threading;
using System.Threading.Tasks;
using Wykop.ApiProvider.Data;

namespace Wykop.ApiProvider.DataProviders
{
    public interface IWykopDataProvider<in TRequest, TResult>
        where TRequest : WykopRequestBase
    {
        Task<TResult> GetData(TRequest fromRequest, CancellationToken cancellationToken);
    }
}