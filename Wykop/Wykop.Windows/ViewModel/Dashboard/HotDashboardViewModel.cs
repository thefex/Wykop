using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Wykop.ApiProvider.Data.Entry;
using Wykop.ApiProvider.Data.Entry.Stream;
using Wykop.ApiProvider.DataProviders.Interfaces;
using Wykop.ApiProvider.Model;
using Wykop.View;

namespace Wykop.ViewModel.Dashboard
{
    public class HotDashboardViewModel : BaseViewModel
    {
        private readonly IWykopDataCollectionProvider<EntriesRequest, Entry> _entriesProvider;

        public HotDashboardViewModel(IWykopDataCollectionProvider<EntriesRequest, Entry> entriesProvider, ViewServices viewServices)
            : base(viewServices)
        {
            _entriesProvider = entriesProvider;
            HotEntries = new ObservableCollection<Entry>();
        }

        public ObservableCollection<Entry> HotEntries { get; private set; }

        public override async Task Load()
        {
            await base.Load();
            await RefreshHotEntries();
        }

        private async Task RefreshHotEntries()
        {
            var hotEntriesRequest = new StreamHotEntriesRequest()
            {
                ShouldIncludeHtml = false
            };
            var hotEntries = await _entriesProvider.GetDataCollection(hotEntriesRequest, CurrentCancellationToken);

            HotEntries = new ObservableCollection<Entry>(hotEntries);
        }
    }
}