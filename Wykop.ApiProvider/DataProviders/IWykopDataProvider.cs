using System.Threading;
using System.Threading.Tasks;
using Wykop.ApiProvider.Data;

namespace Wykop.ApiProvider.DataProviders
{
    public interface IWykopDataProvider
    {
        Task<TResult> GetData<TRequest, TResult>(TRequest fromRequest, CancellationToken cancellationToken)
            where TRequest : WykopRequestBase;
    }
}