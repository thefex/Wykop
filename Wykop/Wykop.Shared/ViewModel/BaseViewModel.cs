using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using Wykop.View;

namespace Wykop.ViewModel
{
    public class BaseViewModel : ViewModelBase
    {
        private readonly ViewServices _viewServices;

        public BaseViewModel(ViewServices viewServices)
        {
            _viewServices = viewServices;
        }

        public INavigationService Navigation { get { return _viewServices.Navigation; } }
        public IDialogService Dialog { get { return _viewServices.Dialog; } }
    }
}