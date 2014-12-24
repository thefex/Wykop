using System;

namespace Wykop.ApiProvider.Data.Exceptions
{
    public class RequestCouldNotBeBuildException : InvalidOperationException
    {
        public RequestCouldNotBeBuildException(string reason)
            : base(reason)
        {
        }
    }
}