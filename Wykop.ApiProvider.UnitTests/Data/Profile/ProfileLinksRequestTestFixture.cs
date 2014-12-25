using NUnit.Framework;
using Wykop.ApiProvider.Data.Exceptions;
using Wykop.ApiProvider.Data.Link.Profile;

namespace Wykop.ApiProvider.UnitTests.Data.Profile
{
    [TestFixture]
    public class ProfileLinksRequestTestFixture : WykopRequestBaseTestFixture
    {
        [Test]
        public void BuildRestRequest_RequestedUsernameIsEmpty_ShouldThrowRequestCouldNotBeBuild()
        {
            var sut = new ProfileIndexLinksRequest("");

            Assert.Throws<RequestCouldNotBeBuildException>(() => sut.BuildRestRequest());
        }
    }
}