using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using RestSharp.Portable;
using Wykop.ApiProvider.Common.Extensions;

namespace Wykop.ApiProvider.Data.LinkRequest
{
    public abstract class LinksRequest
    {
        protected LinksRequest()
        {
            RequestParameters = new List<Parameter>();
            ApiParameters = new List<ApiParameter>();
            RequestHttpMethod = HttpMethod.Get;
        }

        private IList<Parameter> RequestParameters { get; set; }
        private IList<ApiParameter> ApiParameters { get; set; }
        protected HttpMethod RequestHttpMethod { get; set; }
        internal abstract string GetResourceTypeName();
        internal abstract string GetResourceMethodName();

        protected virtual void BuildParameters()
        {
        }

        protected void AddParameterToRequest(Parameter parameter)
        {
            RequestParameters.Add(parameter);
        }

        protected void AddApiParameterToRequest(ApiParameter apiParameter)
        {
            ApiParameters.Add(apiParameter);
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
            var apiParametersString = String.Empty;

            if (ApiParameters.Any())
            {
                apiParametersString =
                    ApiParameters.Select(x => x.ToString())
                        .Aggregate((before, current) => before + "," + current);
            }

            var resourceUrl = GetResourceTypeName() + "/" + GetResourceMethodName();

            return resourceUrl + "/" + apiParametersString;
        }
    }
}