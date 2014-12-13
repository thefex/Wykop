using Ninject.Modules;
using Wykop.ApiProvider.Common;
using Wykop.ApiProvider.Data;
using Wykop.ApiProvider.Links;
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
            Bind<ILinksProvider>().To<LinksProvider>().InSingletonScope();
            Bind<ViewServices>().ToSelf();
        }
    }
}