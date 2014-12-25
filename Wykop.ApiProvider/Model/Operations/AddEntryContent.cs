using System;

namespace Wykop.ApiProvider.Model.Operations
{
    public class AddEntryContent
    {
        public AddEntryContent(string body, Uri mediaUri)
        {
            Body = body;
            MediaUri = mediaUri;
        }

        public string Body { get; private set; }
        public Uri MediaUri { get; private set; }
    }
}