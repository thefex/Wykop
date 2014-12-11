using Wykop.ApiProvider.Data.Types;

namespace Wykop.ApiProvider.Data.LinkRequest.Links
{
    public abstract class MainLinksRequest : LinksRequest
    {
        public int RequestedPage { get; set; }
        public SortType SortType { get; set; }

        internal override string GetResourceTypeName()
        {
            return "Links";
        }
    }
}
