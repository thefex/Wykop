namespace Wykop.ApiProvider.Data.LinkRequest.Search
{
    public abstract class BaseSearchLinksRequest : LinksRequest
    {
        internal override string GetResourceTypeName()
        {
            return "Search";
        }
    }
}