using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Wykop.ApiProvider.Data.LinkRequest.Links;
using Wykop.ApiProvider.Data.Types;
using Wykop.ApiProvider.Links;
using Wykop.ApiProvider.Model;
using Wykop.View;

namespace Wykop.ViewModel.Dashboard
{
    public class WykopaliskoDashboardViewModel : BaseViewModel
    {
        private readonly ILinksProvider _linksProvider;

        public WykopaliskoDashboardViewModel(ILinksProvider linksProvider, ViewServices viewServices) : base(viewServices)
        {
            _linksProvider = linksProvider;
            WykopaliskoLinks = new ObservableCollection<Link>();
        }

        public ObservableCollection<Link> WykopaliskoLinks { get; private set; }

        public override async Task Load()
        {
            await base.Load();
            await RefreshLinks();
        }

        private async Task RefreshLinks()
        {
            var upcomingLinksRequest = new UpcomingMainLinksRequest()
            {
                RequestedPage = 1,
                SortType = SortType.CreateSortByDay()
            };

            var upcomingLinks = await _linksProvider.GetLinks(upcomingLinksRequest, CurrentCancellationToken);
            WykopaliskoLinks = new ObservableCollection<Link>(upcomingLinks);
        }
    }
}