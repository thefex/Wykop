using System.Collections.Generic;
using System.Net.Http;
using RestSharp.Portable;
using Wykop.ApiProvider.Common.Extensions;
using Wykop.ApiProvider.Data.LinkRequest.Helpers;

namespace Wykop.ApiProvider.Data.LinkRequest
{
    public abstract class LinksRequest
    {
        internal abstract string GetResourceTypeName();
        internal abstract string GetResourceMethodName();

        protected LinksRequest()
        {
            RequestParameters = new List<Parameter>();
            RequestHttpMethod = HttpMethod.Get;
        }

        private IList<Parameter> RequestParameters { get; set; }

        protected System.Net.Http.HttpMethod RequestHttpMethod { get; set; }

        protected virtual void BuildParameters()
        {
            var appKeyParameter = ApiParameterProvider.GetApplicationKeyParameter();
            AddParameterToRequest(appKeyParameter);
        }

        protected void AddParameterToRequest(Parameter parameter)
        {
            RequestParameters.Add(parameter);
        }

        internal RestRequest BuildRestRequest()
        {
            var restRequest = new RestRequest(RequestHttpMethod);
            restRequest.Resource = GetResourceTypeName() + "/" + GetResourceMethodName();

            foreach(var parameter in RequestParameters)
                restRequest.Parameters.Add(parameter);

           // restRequest.SignWykopRequest();

            return restRequest;
        }
    }
}