using System;
using Wykop.ApiProvider.Data.LinkRequest.Top;

namespace Wykop.ApiProvider.Data.Link.Top
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

            var yearParameter = new MethodParameter() { Value = ForYearMonthDate.Year.ToString() };
            var monthParameter = new MethodParameter() { Value = ForYearMonthDate.Month.ToString() };
         
            AddMethodParameterToRequest(yearParameter);
            AddMethodParameterToRequest(monthParameter);
        }
    }
}