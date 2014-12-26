using Ninject.Modules;
using Wykop.ApiProvider.Common;
using Wykop.ApiProvider.Data;
using Wykop.ApiProvider.Data.Entry;
using Wykop.ApiProvider.DataCreators;
using Wykop.ApiProvider.DataProviders;
using Wykop.ApiProvider.DataProviders.Interfaces;
using Wykop.ApiProvider.Links;
using Wykop.ApiProvider.Login;
using Wykop.ApiProvider.Model;
using Wykop.View;

namespace Wykop.Common
{
    internal class SharedNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IApiDataContainer>()
                .To<ApplicationSettingsDataContainer>()
                .InSingletonScope();

            Bind<ILoginService>()
                .To<LoginService>()
                .InSingletonScope();

            Bind<ILinksProvider>()
                .To<LinksProvider>()
                .InSingletonScope();

            Bind<IWykopDataCollectionProvider<EntriesRequest, Entry>>()
                .To<DefaultWykopDataCollectionProvider<EntriesRequest, Entry>>()
                .InSingletonScope();

            Bind<IWykopDataProvider>()
                .To<DefaultWykopDataProvider>();

            Bind<IUserWykopDataProvider>()
                .To<LoggedUserWykopDataProvider>();

            Bind<IEntriesCreator>().To<LoggedUserEntriesCreator>();
            Bind<IPrivateMessageSender>().To<PrivateMessageSender>();

            Bind<ViewServices>().ToSelf();
        }
    }
}