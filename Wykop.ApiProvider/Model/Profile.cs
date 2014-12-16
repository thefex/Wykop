using System;
using Newtonsoft.Json;

namespace Wykop.ApiProvider.Model
{
    public class Profile
    {
        [JsonProperty("login")]
        public string Login { get; internal set; }

        [JsonProperty("email")]
        public string MailAddress { get; internal set; }

        [JsonProperty("public_email")]
        public string PublicMail { get; internal set; }

        [JsonProperty("name")]
        public string Name { get; internal set; }

        [JsonProperty("www")]
        public Uri HomePage { get; internal set; }

        [JsonProperty("jabber")]
        public string Jabber { get; internal set; }

        [JsonProperty("gg")]
        public int? GaduGadu { get; internal set; }

        [JsonProperty("city")]
        public string City { get; internal set; }

        [JsonProperty("about")]
        public string About { get; internal set; }

        [JsonProperty("author_group")]
        public int AuthorGroup { get; internal set; }

        [JsonProperty("links_added")]
        public int AddedLinksCount { get; internal set; }

        [JsonProperty("links_published")]
        public int PublishedLinksCount { get; internal set; }

        [JsonProperty("comments")]
        public int CommentsCount { get; internal set; }

        [JsonProperty("rank")]
        public int RankingPlace { get; internal set; }

        [JsonProperty("followers")]
        public int FollowersCount { get; internal set; }

        [JsonProperty("following")]
        public int FollowedCount { get; internal set; }

        [JsonProperty("entries")]
        public int EntriesCount { get; internal set; }

        [JsonProperty("entries_comment")]
        public int EntriesCommentsCount { get; internal set; }

        [JsonProperty("diggs")]
        public int DiggedLinksCount { get; internal set; }

        [JsonProperty("buries")]
        public int BurriedLinskCount { get; internal set; }

        [JsonProperty("related_links")]
        public int RelatedLinksCount { get; internal set; }

        [JsonProperty("groups")]
        public int GroupsCount { get; internal set; }

        //TODO: change to avatar..
        [JsonProperty("avatar")]
        public Uri DefaultAvatar { get; internal set; }

        [JsonProperty("avatar_lo")]
        public Uri SmallAvatar { get; internal set; }

        [JsonProperty("avatar_med")]
        public Uri MediumAvatar { get; internal set; }

        [JsonProperty("avatar_big")]
        public Uri BigAvatar { get; internal set; }

        [JsonProperty("is_observed")]
        public bool? IsObserved { get; internal set; }
    }
}