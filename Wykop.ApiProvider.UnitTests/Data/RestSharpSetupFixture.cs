using NUnit.Framework;
using Wykop.ApiProvider.Common;

namespace Wykop.ApiProvider.UnitTests.Data
{
    [SetUpFixture]
    public class RestSharpSetupFixture
    {
        [SetUp]
        public void SetupWykopApiConfig()
        {
            WykopApiConfiguration.SetApiKey(UnitTestsConstants.AppKey);
            WykopApiConfiguration.SetApiSecret(UnitTestsConstants.ApiSecret);
            WykopApiConfiguration.SetApplicationName(UnitTestsConstants.AppName);
        }
    }
}