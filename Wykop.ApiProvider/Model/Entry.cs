using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Wykop.ApiProvider.Model.JSONDeserializers.Converter;

namespace Wykop.ApiProvider.Model
{
    public class Entry
    {
        [JsonConstructor]
        internal Entry(int id)
        {
            Id = id;
        }

        public int Id { get; internal set; }

        [JsonProperty("author")]
        public string Author { get; internal set; }

        //TODO: try to extract it to Avatar object
        [JsonProperty("author_avatar")]
        public Uri DefaultAvatarSource { get; internal set; }

        [JsonProperty("author_avatar_med")]
        public Uri SmallAvatarSource { get; internal set; }

        [JsonProperty("author_avatar_lo")]
        public Uri MediumAvatarSource { get; internal set; }

        //end TODO

        [JsonProperty("author_group")]
        public int AuthorGroup { get; internal set; }

        [JsonProperty("date")]
        public DateTime CreatedDate { get; internal set; }

        [JsonProperty("body")]
        public string Body { get; internal set; }

        [JsonProperty("url")]
        public Uri Url { get; internal set; }

        //// TODO: extract it to avatar object
        //[JsonProperty("receiver")]
        //public string Receiver { get; internal set; }

        //[JsonProperty("receiver_avatar_med")]
        //public Uri ReceiverMediumAvatar { get; internal set; }

        //[JsonProperty("receiver_avatar_lo")]
        //public Uri ReceiverSmallAvatar { get; internal set; }

        //[JsonProperty("receiver_avatar")]
        //public Uri ReceiverDefaultAvatar { get; internal set; }

        //[JsonProperty("receiver_group")]
        //public int ReceiverGroup { get; internal set; }

        // end todo

        // todo add comments, voters, user_favorite,embed property

        [JsonProperty("embed")]
        public Embed EmbeddedMedia { get; internal set; }

        [JsonProperty("vote_count")]
        public uint VoteCount { get; internal set; }
    }
}