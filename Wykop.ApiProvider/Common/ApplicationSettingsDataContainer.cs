using System.Threading.Tasks;
using Windows.Storage;
using Wykop.ApiProvider.Data;

namespace Wykop.ApiProvider.Common
{
    public class ApplicationSettingsDataContainer : IApiDataContainer
    {
        private readonly ApplicationDataContainer _dataContainer;

        public ApplicationSettingsDataContainer()
        {
            _dataContainer = ApplicationData.Current.LocalSettings;
        }

        public Task Save(string key, string value)
        {
            _dataContainer.Values[key] = value;

            return Task.FromResult(true);
        }

        public Task<string> Retrieve(string dataFromKey)
        {
            var data = _dataContainer.Values[dataFromKey] as string;
            return Task.FromResult(data);
        }
    }
}