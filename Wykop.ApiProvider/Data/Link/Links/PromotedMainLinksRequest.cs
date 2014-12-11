namespace Wykop.ApiProvider.Data.LinkRequest.Links
{
    public class PromotedMainLinksRequest : MainLinksRequest
    {
        internal override string GetResourceMethodName()
        {
            return "Promoted";
        }
    }
}