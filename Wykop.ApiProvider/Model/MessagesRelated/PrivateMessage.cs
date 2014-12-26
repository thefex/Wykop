using System;
using Newtonsoft.Json;

namespace Wykop.ApiProvider.Model.MessagesRelated
{
    public class PrivateMessage : SerializableModel
    {
        [JsonProperty("date")]
        public DateTime MessageDate { get; internal set; }

        // TODO: don't have time atm to do smth like this: 
        // http://stackoverflow.com/questions/27460522/json-net-controlling-class-object-properties-deserialization
        [JsonProperty("author_avatar")]
        public Uri AuthorAvatar { get; internal set; }

        [JsonProperty("author_avatar_med")]
        public Uri AuthorAvatarMedium { get; internal set; }

        [JsonProperty("author_avatar_lo")]
        public Uri AuthorAvatarLow { get; internal set; }

        [JsonProperty("author_group")]
        public int AuthorGroup { get; internal set; }

        [JsonProperty("author_sex")]
        public string AuthorSex { get; internal set; }

        [JsonProperty("body")]
        public string Body { get; internal set; }

        [JsonProperty("status")]
        public string Status { get; internal set; }

        [JsonProperty("direction")]
        public string Direction { get; internal set; }
    }
}