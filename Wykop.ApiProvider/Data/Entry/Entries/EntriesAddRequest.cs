using System;
using RestSharp.Portable;
using Wykop.ApiProvider.Data.Exceptions;
using Wykop.ApiProvider.Data.LinkRequest.Helpers;

namespace Wykop.ApiProvider.Data.Entry.Entries
{
    public class EntriesAddRequest : EntriesResourceRequest
    {
        public string UserKey { get; set; }
        public string Body { get; set; }
        public Uri EmbeddedMediaUri { get; set; }

        internal override string GetResourceMethodName()
        {
            return "Add";
        }

        protected override void BuildParameters()
        {
            base.BuildParameters();

            AddApiParameters();
            AddPostParameters();
        }

        private void AddApiParameters()
        {
            if (string.IsNullOrEmpty(UserKey))
                throw new RequestCouldNotBeBuildException("Missing UserKey field.");

            var userKeyApiParameter = ApiParameterProvider.GetUserKeyParameter(UserKey);
            var appKeyApiParameter = ApiParameterProvider.GetApplicationKeyParameter();

            AddApiParameterToRequest(userKeyApiParameter);
            AddApiParameterToRequest(appKeyApiParameter);
        }

        private void AddPostParameters()
        {
            var bodyParameter = new Parameter
            {
                Name = "body",
                Value = Body,
                Type = ParameterType.RequestBody
            };
            var embeddedMediaParameter = new Parameter
            {
                Name = "embed",
                Value = EmbeddedMediaUri.OriginalString,
                Type = ParameterType.RequestBody
            };

            AddParameterToRequest(bodyParameter);
            AddParameterToRequest(embeddedMediaParameter);
        }
    }
}