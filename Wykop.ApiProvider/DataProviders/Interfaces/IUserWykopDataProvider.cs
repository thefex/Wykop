using System.Threading;
using System.Threading.Tasks;
using Wykop.ApiProvider.Data;

namespace Wykop.ApiProvider.DataProviders.Interfaces
{
    public interface IUserWykopDataProvider : IWykopDataProvider
    {
        Task<TResult> GetUserData<TRequest, TResult>(TRequest fromRequest, CancellationToken cancellationToken)
            where TRequest : WykopRequestBase, IAuthorizable;
    }
}