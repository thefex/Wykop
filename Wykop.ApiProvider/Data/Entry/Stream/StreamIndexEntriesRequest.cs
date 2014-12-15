namespace Wykop.ApiProvider.Data.Entry.Stream
{
    public class StreamIndexEntriesRequest : StreamEntriesRequest
    {
        internal override string GetResourceMethodName()
        {
            return "Index";
        }
    }
}