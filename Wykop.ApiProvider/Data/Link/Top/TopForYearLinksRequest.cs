using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wykop.ApiProvider.Data.LinkRequest.Helpers;

namespace Wykop.ApiProvider.Data.LinkRequest.Top
{
    public class TopForYearLinksRequest : TopLinksRequest
    {
        public DateTime ForYearDate { get; set; }

        internal override string GetResourceMethodName()
        {
            return "Index";
        }

        protected override void BuildParameters()
        {
            base.BuildParameters();

            var yearParameter = MethodParameterProvider.GetYearParameter("param1", ForYearDate);
            AddParameterToRequest(yearParameter);
        }
    }
}
