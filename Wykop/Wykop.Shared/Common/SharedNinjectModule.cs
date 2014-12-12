using Ninject.Modules;
using Wykop.ApiProvider.Common;
using Wykop.ApiProvider.Data;
using Wykop.ApiProvider.Login;
using Wykop.View;

namespace Wykop.Common
{
    internal class SharedNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IApiDataContainer>().To<ApplicationSettingsDataContainer>().InSingletonScope();
            Bind<ILoginService>().To<LoginService>().InSingletonScope();
            Bind<ViewServices>().ToSelf();
        }
    }
}