using GalaSoft.MvvmLight.Views;

namespace Wykop.View
{
    public class ViewServices
    {
        public ViewServices(INavigationService navigation, IDialogService dialogService)
        {
            Navigation = navigation;
            Dialog = dialogService;
        }

        public INavigationService Navigation { get; private set; }
        public IDialogService Dialog { get; private set; }
    }
}