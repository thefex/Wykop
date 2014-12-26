namespace Wykop.ApiProvider.Data
{
    public interface IAuthorizable
    {
        void AuthorizeRequest(string userKey);
    }
}