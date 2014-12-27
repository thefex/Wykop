using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using Wykop.ApiProvider.DataProviders;
using Wykop.ApiProvider.Login;
using Wykop.ApiProvider.Model;
using Wykop.ApiProvider.Model.Extensions;
using Wykop.Common;
using Wykop.View;

namespace Wykop.ViewModel.Dashboard
{
    public class UserObservedTagsViewModel : BaseViewModel
    {
        private readonly IWykopDataProvider _wykopDataProvider;

        public UserObservedTagsViewModel(IWykopDataProvider wykopDataProvider, ViewServices viewServices) : base(viewServices)
        {
            _wykopDataProvider = wykopDataProvider;
            ObservedTags = Enumerable.Empty<Tag>().ToList();
            MessengerInstance.Register<LoggedUser>(this, MessengerTokens.DashboardLoggedUserDeliveryToken,
                async (loggedUser) =>
                {
                    Contract.Assert(loggedUser != null);
                    await UpdateObservedTags(loggedUser);
                });
        }

        public IList<Tag> ObservedTags { get; set; }

        public async Task UpdateObservedTags(LoggedUser loggedUser)
        {
            ObservedTags = await loggedUser.GetObservedTags(_wykopDataProvider, CurrentCancellationToken);
        }
    }
}