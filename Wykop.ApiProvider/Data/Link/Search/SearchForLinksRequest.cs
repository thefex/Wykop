using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wykop.ApiProvider.Data.LinkRequest.Search
{
    public class SearchForLinksRequest : BaseSearchLinksRequest
    {
        public int RequestedPage { get; set; }
        public string SearchQuery { get; set; }

        internal override string GetResourceMethodName()
        {
            return "Links";
        }

        protected override void BuildParameters()
        {
            base.BuildParameters();
        }
    }
}
