using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Wykop.ApiProvider.Data.PMMessage.PM;
using Wykop.ApiProvider.DataProviders.Interfaces;
using Wykop.ApiProvider.Model.MessagesRelated;

namespace Wykop.ApiProvider.Model.Extensions
{
    public static class ConversationListExtensions
    {
        public static Task<IList<PrivateMessage>> GetAllMessages(this ConversationList conversationList,
            IUserWykopDataProvider dataProvider)
        {
            return conversationList.GetAllMessages(dataProvider, CancellationToken.None);
        }

        public static async Task<IList<PrivateMessage>> GetAllMessages(this ConversationList conversationList,
            IUserWykopDataProvider dataProvider, CancellationToken cancellationToken)
        {
            var conversationRequest = new ConversationsRequest
            {
                RequestedUsername = conversationList.Author
            };

            return
                await
                    dataProvider.GetUserData<ConversationsRequest, List<PrivateMessage>>(conversationRequest,
                        cancellationToken)
                        .ConfigureAwait(false);
        }
    }
}