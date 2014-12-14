using Wykop.ApiProvider.Data.LinkRequest.Helpers;

namespace Wykop.ApiProvider.Data.Entry.Stream
{
    public abstract class StreamEntriesRequest : EntriesRequest
    {
        protected StreamEntriesRequest()
        {
            RequestedPage = 1;
        }

        public int RequestedPage { get; set; }

        internal override string GetResourceTypeName()
        {
            return "Stream";
        }

        protected override void BuildParameters()
        {
            base.BuildParameters();

            var appKeyParameter = ApiParameterProvider.GetApplicationKeyParameter();
            var pageParameter = ApiParameterProvider.GetPageParameter(RequestedPage);

            AddApiParameterToRequest(appKeyParameter);
            AddApiParameterToRequest(pageParameter);
        }
    }
}