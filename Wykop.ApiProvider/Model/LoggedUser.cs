using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Wykop.ApiProvider.Data.MyWykop;
using Wykop.ApiProvider.Data.Types;
using Wykop.ApiProvider.DataProviders;

namespace Wykop.ApiProvider.Model
{
    public class LoggedUser : Profile
    {
        private readonly DefaultWykopDataProvider _notificationCountProvider;

        public LoggedUser()
        {
            _notificationCountProvider = new DefaultWykopDataProvider();
        }

        // TODO:check singup date etc.. (fields aren't docummented @api)
        [JsonProperty("userkey")]
        public string UserKey { get; internal set; }

        public Task<int> GetNotificationCount(NotificationType notificationType, CancellationToken cancellationToken)
        {
            MyWykopRequest myWykopRequest;

            if (notificationType == NotificationType.PrivateMessage)
                myWykopRequest = new MyWykopNotificationsCountRequest(this);
            else
                myWykopRequest = new MyWykopHashTagsNotificationsCountRequest(this);

            return _notificationCountProvider.GetData<MyWykopRequest, int>(myWykopRequest, cancellationToken);
        }
    }
}