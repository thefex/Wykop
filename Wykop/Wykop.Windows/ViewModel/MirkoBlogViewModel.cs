using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Wykop.ApiProvider.Data.Entry;
using Wykop.ApiProvider.Data.Entry.Stream;
using Wykop.ApiProvider.DataProviders;
using Wykop.ApiProvider.Model;
using Wykop.View;

namespace Wykop.ViewModel
{
    public class MirkoBlogViewModel : BaseViewModel
    {
        private readonly IWykopDataCollectionProvider<EntriesRequest, Entry> _entriesProvider;

        public MirkoBlogViewModel(IWykopDataCollectionProvider<EntriesRequest, Entry> entriesProvider, ViewServices viewServices)
            : base(viewServices)
        {
            _entriesProvider = entriesProvider;
            Entries = new ObservableCollection<Entry>();
        }

        public ObservableCollection<Entry> Entries { get; set; }

        public override async Task Load()
        {
            await base.Load();
            await LoadEntries();
        }

        private async Task LoadEntries()
        {
            var indexEntriesRequest = new StreamIndexEntriesRequest()
            {
                RequestedPage = 1,
                ShouldIncludeHtml = false
            };

            var indexEntries = await _entriesProvider.GetDataCollection(indexEntriesRequest, CurrentCancellationToken);
            Entries = new ObservableCollection<Entry>(indexEntries);
        }
    }
}