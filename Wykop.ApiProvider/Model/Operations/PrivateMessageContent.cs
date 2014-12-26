using System;
using System.Diagnostics.Contracts;

namespace Wykop.ApiProvider.Model.Operations
{
    public struct PrivateMessageContent
    {
        public readonly string Body;
        public readonly Uri EmbeddedUri;
        public readonly string UsernameTarget;

        public PrivateMessageContent(string targetUsername, string body)
            : this(targetUsername, body, null)
        {
        }

        public PrivateMessageContent(string targetUsername, Uri embeddedUri)
            : this(targetUsername, string.Empty, embeddedUri)
        {
        }

        public PrivateMessageContent(string targetUsername, string body, Uri embeddedUri)
        {
            UsernameTarget = targetUsername;
            Body = body;
            EmbeddedUri = embeddedUri;
        }

        [Pure]
        public bool IsValidPrivateMessage()
        {
            return !string.IsNullOrEmpty(UsernameTarget) && (!string.IsNullOrEmpty(Body) || EmbeddedUri != null);
        }
    }
}