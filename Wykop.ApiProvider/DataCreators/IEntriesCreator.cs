using System.Threading;
using System.Threading.Tasks;
using Wykop.ApiProvider.Model.Operations;

namespace Wykop.ApiProvider.DataCreators
{
    public interface IEntriesCreator
    {
        Task<EntryAddResult> AddEntry(AddEntryContent entryContent, CancellationToken cancellationToken);
    }
}