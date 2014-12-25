using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using RestSharp.Portable;
using Wykop.ApiProvider.Common.Extensions;

namespace Wykop.ApiProvider.Data
{
    public abstract class WykopRequestBase
    {
        protected WykopRequestBase()
        {
            RequestParameters = new List<Parameter>();
            ApiParameters = new List<ApiParameter>();
            MethodParameters = new List<MethodParameter>();

            RequestHttpMethod = HttpMethod.Get;
            ShouldIncludeHtml = true;
        }

        public bool ShouldIncludeHtml { get; set; }
        private IList<Parameter> RequestParameters { get; set; }
        private IList<ApiParameter> ApiParameters { get; set; }
        private IList<MethodParameter> MethodParameters { get; set; }
        protected HttpMethod RequestHttpMethod { get; set; }
        internal abstract string GetResourceTypeName();
        internal abstract string GetResourceMethodName();

        protected virtual void BuildParameters()
        {
        }

        protected void AddMethodParameterToRequest(MethodParameter methodParameter)
        {
            MethodParameters.Add(methodParameter);
        }

        protected void AddApiParameterToRequest(ApiParameter apiParameter)
        {
            ApiParameters.Add(apiParameter);
        }

        protected void AddParameterToRequest(Parameter parameter)
        {
            RequestParameters.Add(parameter);
        }

        internal RestRequest BuildRestRequest()
        {
            BuildParameters();

            var restRequest = new RestRequest(RequestHttpMethod)
            {
                Resource = BuildResourceUrl()
            };

            foreach (var parameter in RequestParameters)
                restRequest.Parameters.Add(parameter);

            restRequest.SignWykopRequest();

            return restRequest;
        }

        private string BuildResourceUrl()
        {
            string resourceUrl = GetResourceTypeName() + "/" + GetResourceMethodName();

            string methodParameters = GetMethodParametersString();
            string apiParameters = GetApiParametersString();

            if (!string.IsNullOrEmpty(methodParameters))
                resourceUrl += "/" + GetMethodParametersString();
            if (!string.IsNullOrEmpty(apiParameters))
                resourceUrl += "/" + GetApiParametersString();

            return resourceUrl;
        }

        private string GetApiParametersString()
        {
            var apiParametersString = string.Empty;

            if (ApiParameters.Any())
            {
                apiParametersString =
                    ApiParameters
                        .Select(x => x.ToString())
                        .Aggregate((before, current) => before + "," + current);
            }

            if (!ShouldIncludeHtml)
            {
                apiParametersString += (string.IsNullOrWhiteSpace(apiParametersString)) ? "" : ",";
                apiParametersString += "output,clear";
            }

            return apiParametersString;
        }

        private string GetMethodParametersString()
        {
            if (!MethodParameters.Any())
                return string.Empty;

            return MethodParameters
                .Select(x => x.ToString())
                .Aggregate((previous, current) => previous + "/" + current);
        }
    }
}