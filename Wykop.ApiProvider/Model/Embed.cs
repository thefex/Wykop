using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Wykop.ApiProvider.Model
{
    [JsonObject]
    public class Embed
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("preview")]
        public Uri Preview { get; internal set; }

        [JsonProperty("url")]
        public Uri Url { get; internal set; }

        [JsonProperty("source")]
        public string Source { get; internal set; }

        [JsonProperty("plus18")]
        public bool IsForAdult { get; internal set; }
    }
}
