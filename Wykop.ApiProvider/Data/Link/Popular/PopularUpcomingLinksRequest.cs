namespace Wykop.ApiProvider.Data.LinkRequest.Popular
{
    public class PopularUpcomingLinksRequest : PopularLinksRequest
    {
        internal override string GetResourceMethodName()
        {
            return "Upcoming";
        }
    }
}