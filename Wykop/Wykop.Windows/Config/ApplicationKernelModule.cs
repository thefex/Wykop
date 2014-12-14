using GalaSoft.MvvmLight.Views;
using Ninject;
using Ninject.Modules;
using Wykop.Common;
using Wykop.ViewModel;
using Wykop.ViewModel.Dashboard;

namespace Wykop.Config
{
    public class ApplicationKernelModule : NinjectModule
    {
        public override void Load()
        {
            NavigationService navigationService = new NavigationService();
            navigationService.Configure(NavigationPageKeys.DashboardPageKey, typeof(Dashboard));

            Bind<INavigationService>().ToConstant(navigationService);
            Bind<IDialogService>().To<DialogService>();

            BindViewModels();
        }

        private void BindViewModels()
        {
            Bind<DashboardViewModel>().ToSelf()
                .WithPropertyValue("Home", context => context.Kernel.Get<HomeDashboardViewModel>())
                .WithPropertyValue("Wykopalisko", context => context.Kernel.Get<WykopaliskoDashboardViewModel>())
                .WithPropertyValue("Hot", context => context.Kernel.Get<HotDashboardViewModel>());
        }
    }
}