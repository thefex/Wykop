namespace Wykop.ApiProvider.Data.LinkRequest.Links
{
    public class UpcomingMainLinksRequest : MainLinksRequest
    {
        internal override string GetResourceMethodName()
        {
            return "Upcoming";
        }
    }
}