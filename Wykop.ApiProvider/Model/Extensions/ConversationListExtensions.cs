using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Wykop.ApiProvider.Data.PMMessage.PM;
using Wykop.ApiProvider.DataProviders;
using Wykop.ApiProvider.Model.MessagesRelated;

namespace Wykop.ApiProvider.Model.Extensions
{
    public static class ConversationListExtensions
    {
        public static Task<IList<PrivateMessage>> GetAllMessages(this ConversationList conversationList, string userKey,
            IWykopDataProvider dataProvider)
        {
            return conversationList.GetAllMessages(userKey, dataProvider, CancellationToken.None);
        }

        public static async Task<IList<PrivateMessage>> GetAllMessages(this ConversationList conversationList, string userKey,
            IWykopDataProvider dataProvider, CancellationToken cancellationToken)
        {
            var conversationRequest = new ConversationsRequest(userKey)
            {
                RequestedUsername = conversationList.Author
            };

            return await dataProvider.GetData<ConversationsRequest, List<PrivateMessage>>(conversationRequest, cancellationToken)
                .ConfigureAwait(false);
        }
    }
}