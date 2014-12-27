using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Wykop.ApiProvider.Data.ConversationList.PM;
using Wykop.ApiProvider.Data.Tags.User;
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

        public static async Task<IList<Tag>> GetObservedTags(this LoggedUser loggedUser, IWykopDataProvider dataProvider,
            CancellationToken cancellationToken)
        {
            UserTagsRequest userTagsRequest = new UserTagsRequest();
            userTagsRequest.AuthorizeRequest(loggedUser.UserKey);

            var tagsStringList =
                await dataProvider.GetData<UserTagsRequest, IList<string>>(userTagsRequest, cancellationToken);

            return tagsStringList
                .Select(x => new Tag(x.TrimStart('#')))
                .ToList();
        }
    }
}