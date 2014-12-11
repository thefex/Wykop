using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wykop.ApiProvider.Data.LinkRequest.Favorites
{
    public class LoggedUserFavoritesLinksRequest : LinksRequest
    {
        internal override string GetResourceTypeName()
        {
            return "Favorites";
        }

        internal override string GetResourceMethodName()
        {
            throw new NotImplementedException();
        }
    }
}
