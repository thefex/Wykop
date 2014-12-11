namespace Wykop.ApiProvider.Exceptions.ApiExceptions
{
    public enum ApiErrorCode
    {
        InvalidApiKey = 1,
        InvalidParametersSended = 2,
        NotEnoughParameters = 3,
        WritePermissionNotGranted = 4,
        DailyRequestLimitsExceeded = 5,
        InvalidApiSign = 6,
        NotEnoughPermissions = 7,
        InvalidUserKey = 11,
        EmptyUserKey = 12,
        UserDoesntExists = 13,
        InvalidLoginData = 14,
        EmptyLoginOrPassword = 15,
        BannedIP = 17,
        BannedAccount = 18,
        UserCantVoteTheirComments = 31,
        InvalidLinkId = 32,
        UserCantObserveThemself = 33,
        CantEditThisComment = 34,
        CantModifyThisCommentOrEntry = 35,
        LinkIsRemoved = 41,
        PrivateLink = 42,
        EntryDoesNotExists = 61,
        SearchQueryTooShort = 71,
        CommentDoesntExists = 81,
        ApiCheating = 999,
        ServiceMaintenance = 1001,
        NoResourceSpecifedInRequest = 1002
    }
}