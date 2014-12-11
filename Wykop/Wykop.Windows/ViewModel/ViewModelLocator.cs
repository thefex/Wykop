using Ninject;
using Wykop.Config;

namespace Wykop.ViewModel
{
    public class ViewModelLocator
    {
        private readonly IKernel _ninjectKernel;

        public ViewModelLocator()
        {
            _ninjectKernel = new StandardKernel(new ApplicationKernelModule());
        }

        public MainPageViewModel Main
        {
            get { return _ninjectKernel.Get<MainPageViewModel>(); }
        }
    }
}