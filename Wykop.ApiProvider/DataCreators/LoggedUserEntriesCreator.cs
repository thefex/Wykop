using System.Threading;
using System.Threading.Tasks;
using RestSharp.Portable;
using Wykop.ApiProvider.Common.Constants;
using Wykop.ApiProvider.Data.Entry.Entries;
using Wykop.ApiProvider.Exceptions;
using Wykop.ApiProvider.Login;
using Wykop.ApiProvider.Model.Operations;

namespace Wykop.ApiProvider.DataCreators
{
    public class LoggedUserEntriesCreator : IEntriesCreator
    {
        private readonly ILoginService _loginService;
        private readonly RestClient _restClient;

        public LoggedUserEntriesCreator(ILoginService loginService)
        {
            _loginService = loginService;
            _restClient = new RestClient(ApiConstants.HostUrl);
        }

        public async Task<EntryAddResult> AddEntry(AddEntryContent entryContent, CancellationToken cancellationToken)
        {
            var addEntryRequest = new EntriesAddRequest
            {
                Body = entryContent.Body,
                EmbeddedMediaUri = entryContent.MediaUri,
                UserKey = await GetLoggedUserKey()
            };

            var restRequest = addEntryRequest.BuildRestRequest();
            restRequest.ContentCollectionMode = ContentCollectionMode.MultiPart;
            
            var requestResults = await _restClient.Execute<object>(restRequest, cancellationToken);

            if (requestResults.Data == "false")
                return new EntryAddResult {HasEntryBeenAdded = false};

            dynamic addedEntry = requestResults.Data;

            return new EntryAddResult {AddedEntryId = addedEntry.id, HasEntryBeenAdded = true};
        }

        private async Task<string> GetLoggedUserKey()
        {
            var isUserLoggedIn = await _loginService.IsLoggedIn();

            if (!isUserLoggedIn)
                throw new UserIsNotLoggedInException();

            var loggedUser = await _loginService.GetLoggedUser();
            return loggedUser.UserKey;
        }
    }
}