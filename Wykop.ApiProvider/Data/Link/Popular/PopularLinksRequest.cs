using System;

namespace Wykop.ApiProvider.Data.LinkRequest.Popular
{
    public abstract class PopularLinksRequest : LinksRequest
    {
        internal override string GetResourceTypeName()
        {
            return "Popular";
        }
    }
}