using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Wykop.ApiProvider.Data.LinkRequest.Links;
using Wykop.ApiProvider.Data.Types;
using Wykop.ApiProvider.Links;
using Wykop.ApiProvider.Model;
using Wykop.View;

namespace Wykop.ViewModel.Dashboard
{
    public class HomeDashboardViewModel : BaseViewModel
    {
        private readonly ILinksProvider _linksProvider;

        public HomeDashboardViewModel(ILinksProvider linksProvider, ViewServices viewServices) : base(viewServices)
        {
            _linksProvider = linksProvider;
        }

        public ObservableCollection<Link> HomeLinks { get; set; }

        public override async Task Load()
        {
            await base.Load();
            await RefreshHomeLinks();
        }

        private async Task RefreshHomeLinks()
        {
            HomeLinks = new ObservableCollection<Link>();
            var promotedMainLinksRequest = new PromotedMainLinksRequest()
            {
                RequestedPage = 1,
                SortType = SortType.CreateSortByDay()
            };

            foreach (var homeLink in await _linksProvider.GetLinks(promotedMainLinksRequest, CurrentCancellationToken))
                HomeLinks.Add(homeLink);
        }
    }
}