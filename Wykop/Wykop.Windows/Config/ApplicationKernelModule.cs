using GalaSoft.MvvmLight.Views;
using Ninject.Modules;

namespace Wykop.Config
{
    public class ApplicationKernelModule : NinjectModule
    {
        public override void Load()
        {
            Bind<INavigationService>().To<NavigationService>();
            Bind<IDialogService>().To<DialogService>();
        }
    }
}