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
            BindAndConfigureNavigationService();
            Bind<IDialogService>().To<DialogService>();

            BindViewModels();
        }

        private void BindAndConfigureNavigationService()
        {
            NavigationService navigationService = new NavigationService();
            navigationService.Configure(NavigationPageKeys.DashboardPageKey, typeof(Dashboard));
            navigationService.Configure(NavigationPageKeys.MikroblogPageKey, typeof(MikroBlog));

            Bind<INavigationService>().ToConstant(navigationService);
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