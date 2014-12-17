using Wykop.ApiProvider.Model;

namespace Wykop.ApiProvider.Data.MyWykop
{
    public class MyWykopNotificationsCountRequest : MyWykopRequest
    {
        public MyWykopNotificationsCountRequest(LoggedUser loggedUser) : base(loggedUser)
        {
        }

        public MyWykopNotificationsCountRequest(string userKey) : base(userKey)
        {
        }

        internal override string GetResourceMethodName()
        {
            return "NotificationsCount";
        }
    }
}