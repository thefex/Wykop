namespace Wykop.ApiProvider.Data.Entry.Entries
{
    public abstract class EntriesResourceRequest : EntriesRequest
    {
        internal override string GetResourceTypeName()
        {
            return "Entries";
        }
    }
}