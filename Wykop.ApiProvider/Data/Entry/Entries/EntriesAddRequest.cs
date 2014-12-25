using System;
using System.Net.Http;
using System.Text;
using RestSharp.Portable;
using Wykop.ApiProvider.Data.Exceptions;
using Wykop.ApiProvider.Data.LinkRequest.Helpers;

namespace Wykop.ApiProvider.Data.Entry.Entries
{
    internal class EntriesAddRequest : EntriesResourceRequest
    {
        public EntriesAddRequest()
        {
            RequestHttpMethod = HttpMethod.Post;
        }

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
            if (string.IsNullOrEmpty(Body) && EmbeddedMediaUri == null)
                throw new RequestCouldNotBeBuildException(
                    "Missing Body and EmbeddedMedia - at least one should be provided.");

            var bodyParameter = new Parameter
            {
                Name = "body",
                Value = Body,
                Type = ParameterType.GetOrPost,
                Encoding = Encoding.UTF8
            };
            AddParameterToRequest(bodyParameter);

            if (EmbeddedMediaUri != null)
            {
                var embeddedMediaParameter = new Parameter
                {
                    Name = "embed",
                    Value = EmbeddedMediaUri.OriginalString,
                    Type = ParameterType.GetOrPost
                };
                AddParameterToRequest(embeddedMediaParameter);
            }
        }
    }
}