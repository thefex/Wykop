using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Wykop.ApiProvider.Model.JSONDeserializers.Converter;

namespace Wykop.ApiProvider.Model
{
    public class Link
    {
        [JsonConstructor]
        internal Link(int id)
        {
            Id = id;
        }

        public int Id { get; internal set; }

        [JsonProperty("title")]
        public string Title { get; internal set; }

        [JsonProperty("description")]
        public string Description { get; internal set; }

        [JsonConverter(typeof (TagsConverter))]
        [JsonProperty("tags")]
        public IEnumerable<Tag> Tags { get; internal set; }

        [JsonProperty("url")]
        public Uri Url { get; internal set; }

        [JsonProperty("source_url")]
        public Uri SourceUrl { get; internal set; }

        [JsonProperty("vote_count")]
        public uint VoteCount { get; internal set; }

        [JsonProperty("comment_count")]
        public uint CommentsCount { get; internal set; }

        [JsonProperty("report_count")]
        public uint ReportsCount { get; internal set; }

        [JsonProperty("date")]
        public DateTime CreatedDate { get; internal set; }

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

        [JsonProperty("preview")]
        public Uri PreviewImage { get; internal set; }

        [JsonConverter(typeof(UsersListConverter))]
        [JsonProperty("user_lists")]
        public UsersIdList UsersIdLists { get; internal set; }

        [JsonProperty("plus18")]
        public bool IsMarkedForAdults { get; internal set; }

        [JsonProperty("status")]
        public string Status { get; internal set; }

        [JsonProperty("can_vote")]
        public bool CanBeVoted { get; internal set; }

        [JsonProperty("has_own_content")]
        public bool HasAnyContent { get; internal set; }

        [JsonProperty("category")]
        public string Category { get; internal set; }
    }
}