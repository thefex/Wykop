using Newtonsoft.Json;

namespace Wykop.ApiProvider.Model
{
    public class LoggedUser : Profile
    {
        // TODO:check singup date etc.. (fields aren't docummented @api)

        [JsonProperty("userkey")]
        public string UserKey { get; internal set; }
    }
}