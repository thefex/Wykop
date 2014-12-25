using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Wykop.ApiProvider.Data.ConversationList.PM;
using Wykop.ApiProvider.DataProviders;
using Wykop.ApiProvider.Model.MessagesRelated;

namespace Wykop.ApiProvider.Model.Extensions
{
    public static class LoggedUserExtensions
    {
        public static Task<IList<ConversationList>> GetConversationLists(this LoggedUser loggedUser,
            IWykopDataProvider wykopDataProvider)
        {
            return loggedUser.GetConversationLists(wykopDataProvider, CancellationToken.None);
        }

        public static async Task<IList<ConversationList>> GetConversationLists(this LoggedUser loggedUser,
            IWykopDataProvider wykopDataProvider, CancellationToken cancellationToken)
        {
            ConversationListRequest conversationListRequest = new ConversationListRequest(loggedUser);
            var conversationLists = await wykopDataProvider.GetData<ConversationListRequest, List<ConversationList>>(
                conversationListRequest, cancellationToken);

            return conversationLists;
        }
    }
}