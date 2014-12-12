using Ninject;
using Wykop.Common;
using Wykop.Config;

namespace Wykop.ViewModel
{
    public class ViewModelLocator
    {
        private readonly IKernel _ninjectKernel;

        public ViewModelLocator()
        {
            _ninjectKernel = new StandardKernel(new SharedNinjectModule(), new ApplicationKernelModule());
        }

        public LoginPageViewModel Login
        {
            get { return _ninjectKernel.Get<LoginPageViewModel>(); }
        }
    }
}