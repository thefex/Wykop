using System;
using Newtonsoft.Json;

namespace Wykop.ApiProvider.Model.MessagesRelated
{
    public class ConversationList
    {
        [JsonProperty("last_update")]
        public DateTime LastUpdatedDate { get; internal set; }

        [JsonProperty("author")]
        public string Author { get; internal set; }

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

        [JsonProperty("status")]
        public string MessageStatus { get; internal set; }
    }
}