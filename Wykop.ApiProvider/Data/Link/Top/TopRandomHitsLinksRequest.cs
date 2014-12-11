namespace Wykop.ApiProvider.Data.LinkRequest.Top
{
    public class TopRandomHitsLinksRequest : TopLinksRequest
    {
        internal override string GetResourceMethodName()
        {
            return "Hits";
        }
    }
}