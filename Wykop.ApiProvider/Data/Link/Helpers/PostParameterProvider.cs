using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp.Portable;

namespace Wykop.ApiProvider.Data.LinkRequest.Helpers
{
    public class PostParameterProvider
    {
        public static Parameter GetSearchQueryParameter(string searchQuery)
        {
            return new Parameter()
            {
                Name = "q",
                Value = searchQuery,
                Type = ParameterType.RequestBody
            };
        }
    }
}
