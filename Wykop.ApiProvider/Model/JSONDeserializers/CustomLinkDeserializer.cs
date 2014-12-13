using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp.Portable.Deserializers;

namespace Wykop.ApiProvider.Model.JSONDeserializers
{
    public class CustomLinkDeserializer : JsonDeserializer
    {
        protected override void ConfigureSerializer(JsonSerializer serializer)
        {
            base.ConfigureSerializer(serializer);
        }
    }
}
