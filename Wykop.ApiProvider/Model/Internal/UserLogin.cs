using Newtonsoft.Json;

namespace Wykop.ApiProvider.Model.Internal
{
    internal class UserLogin
    {
        [JsonProperty("userkey")]
        public string UserKey { get; set; }
    }
}