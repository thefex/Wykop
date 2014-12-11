namespace Wykop.ApiProvider.Common.Constants
{
    internal static class ApiConstants
    {
        // static readonly instead of consts to achieve runtime constant behavior (no need to recompile on changes)
        public static readonly string HostUrl = "http://a.wykop.pl/";

        public static readonly string CommentsResourceName = "comments";
        public static readonly string LinkResourceName = "link";
        public static readonly string LinksResourceName = "links";
        public static readonly string PopularResourceName = "popular";
        public static readonly string ProfileResourceName = "profile";
        public static readonly string SearchResourceName = "search";
        public static readonly string UserResourceName = "user";
        public static readonly string TopResourceName = "top";
        public static readonly string AddResourceName = "add";
        public static readonly string RelatedResourceName = "related";
        public static readonly string MyWykopResourceName = "mywykop";
        public static readonly string EntriesResourceName = "entries";
        public static readonly string RankResourceName = "rank";
        public static readonly string ObservatoryResourceName = "observatory";
        public static readonly string FavoritesResourceName = "favorites";
        public static readonly string StreamResourceName = "stream";
        public static readonly string TagResourceName = "tag";
        public static readonly string PrivateMessageResourceName = "pm";
        public static readonly string TagsResourceName = "tags";
    }
}