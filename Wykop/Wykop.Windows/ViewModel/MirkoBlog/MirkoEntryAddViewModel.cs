using System;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using Wykop.ApiProvider.DataCreators;
using Wykop.ApiProvider.Model.Operations;
using Wykop.View;

namespace Wykop.ViewModel.MirkoBlog
{
    public class MirkoEntryAddViewModel : BaseViewModel
    {
        private readonly IEntriesCreator _entriesCreator;

        public MirkoEntryAddViewModel(IEntriesCreator entriesCreator, ViewServices viewServices) : base(viewServices)
        {
            _entriesCreator = entriesCreator;
            AddEntryCommand = new RelayCommand(async () => await AddEntryCommandExecute());
        }

        private async Task AddEntryCommandExecute()
        {
            var entryContent = new AddEntryContent(EntryBody, AttachedMediaResourceUri);
            var addResult = await _entriesCreator.AddEntry(entryContent, CurrentCancellationToken);


        }

        public string EntryBody { get; set; }
        public Uri AttachedMediaResourceUri { get; set; }

        public RelayCommand AddEntryCommand { get; set; }
    }
}