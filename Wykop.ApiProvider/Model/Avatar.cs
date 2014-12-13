using System;
using Newtonsoft.Json;

namespace Wykop.ApiProvider.Model
{
    public class Avatar
    {
        [JsonConstructor]
        internal Avatar()
        {   
        }

        [JsonProperty("author_avatar")]
        public Uri DefaultAvatarSource { get; internal set; }

        [JsonProperty("author_avatar_med")]
        public Uri SmallAvatarSource { get; internal set; }

        [JsonProperty("author_avatar_lo")]
        public Uri MediumAvatarSource { get; internal set; }
    }
}