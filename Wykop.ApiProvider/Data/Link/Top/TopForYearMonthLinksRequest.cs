using System;
using Wykop.ApiProvider.Data.LinkRequest.Helpers;

namespace Wykop.ApiProvider.Data.LinkRequest.Top
{
    public class TopForYearMonthLinksRequest : TopLinksRequest
    {
        public DateTime ForYearMonthDate { get; set; }

        internal override string GetResourceMethodName()
        {
            return "Date";
        }

        protected override void BuildParameters()
        {
            base.BuildParameters();

            var yearParameter = MethodParameterProvider.GetYearParameter("param1", ForYearMonthDate);
            var monthParameter = MethodParameterProvider.GetMonthParameter("param2", ForYearMonthDate);

            AddParameterToRequest(yearParameter);
            AddParameterToRequest(monthParameter);
        }
    }
}