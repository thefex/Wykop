using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Wykop.ApiProvider.Data.MyWykop;
using Wykop.ApiProvider.Data.Types;
using Wykop.ApiProvider.DataProviders;

namespace Wykop.ApiProvider.Model
{
    internal class NotificationCount
    {
        [JsonProperty("count")]
        public int Count { get; set; }
    }

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


        /// <summary>
        /// Gets notification count according to passed notificationtype by sending request to WykopApi.
        /// Returned value is always actual (not cached one).
        /// </summary>
        /// <param name="notificationType">Private Messages or HashTags</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns>Count of requested notification type.</returns>
        public async Task<int> GetNotificationCount(NotificationType notificationType, CancellationToken cancellationToken)
        {
            MyWykopRequest myWykopRequest;

            if (notificationType == NotificationType.PrivateMessage)
                myWykopRequest = new MyWykopNotificationsCountRequest(this);
            else
                myWykopRequest = new MyWykopHashTagsNotificationsCountRequest(this);

            var notificationCount =
                await _notificationCountProvider.GetData<MyWykopRequest, NotificationCount>(myWykopRequest, cancellationToken)
                .ConfigureAwait(false);

            return notificationCount.Count;
        }
    }
}