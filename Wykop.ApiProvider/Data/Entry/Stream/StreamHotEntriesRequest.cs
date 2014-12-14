namespace Wykop.ApiProvider.Data.Entry.Stream
{
    public class StreamHotEntriesRequest : StreamEntriesRequest
    {
        internal override string GetResourceMethodName()
        {
            return "Hot";
        }
    }
}