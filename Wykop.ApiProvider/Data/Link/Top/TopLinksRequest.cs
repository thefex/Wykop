namespace Wykop.ApiProvider.Data.LinkRequest.Top
{
    public abstract class TopLinksRequest : LinksRequest
    {
        internal override string GetResourceTypeName()
        {
            return "Top";
        }
    }
}