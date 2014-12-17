using Wykop.ApiProvider.Model;

namespace Wykop.ApiProvider.Data.MyWykop
{
    public class MyWykopHashTagsNotificationsCountRequest : MyWykopRequest
    {
        public MyWykopHashTagsNotificationsCountRequest(LoggedUser loggedUser) : base(loggedUser)
        {
        }

        public MyWykopHashTagsNotificationsCountRequest(string userKey) : base(userKey)
        {
        }

        internal override string GetResourceMethodName()
        {
            return "HashTagsNotificationsCount";
        }
    }
}