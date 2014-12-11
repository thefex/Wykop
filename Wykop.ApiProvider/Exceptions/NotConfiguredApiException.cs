using System;

namespace Wykop.ApiProvider.Exceptions
{
    public class NotConfiguredApiException : InvalidOperationException
    {
        public NotConfiguredApiException() 
            : base("You need to call WykopApiConfiguration.SetApiKey before using library.")
        {
            
        }

        public NotConfiguredApiException(string reason)
            : base(reason)
        {
        }
    }
}