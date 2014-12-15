using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using Wykop.ApiProvider.Data.Entry;
using Wykop.ApiProvider.Data.Entry.Stream;
using Wykop.ApiProvider.DataProviders;
using Wykop.ApiProvider.Model;
using Wykop.Common;
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
            Entries = new IncrementalLoadingObservableCollection<Entry>(LoadEntries);
        }

        public ObservableCollection<Entry> Entries { get; set; }

        public override async Task Load()
        {
            await base.Load();
        }

        private Task<IEnumerable<Entry>> LoadEntries(int page, CancellationToken cancellationToken)
        {
            var indexEntriesRequest = new StreamIndexEntriesRequest()
            {
                RequestedPage = page,
                ShouldIncludeHtml = false
            };

            return _entriesProvider.GetDataCollection(indexEntriesRequest, CurrentCancellationToken);
        }
    }
}