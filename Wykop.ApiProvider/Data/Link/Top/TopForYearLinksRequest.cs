using System;
using Wykop.ApiProvider.Data.LinkRequest.Top;

namespace Wykop.ApiProvider.Data.Link.Top
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

            var yearParameter = new MethodParameter() { MethodName = "param1", Value = ForYearDate.Year.ToString() };
            AddMethodParameterToRequest(yearParameter);
        }
    }
}
