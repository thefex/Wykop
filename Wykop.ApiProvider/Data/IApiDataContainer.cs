using System.Threading.Tasks;

namespace Wykop.ApiProvider.Data
{
    public interface IApiDataContainer
    {
        Task Save(string key, string value);
        Task<string> Retrieve(string dataFromKey);
    }
}