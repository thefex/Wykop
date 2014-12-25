//using System.Collections.Generic;
//using System.Linq;
//using System.Threading;
//using System.Threading.Tasks;
//using Moq;
//using NUnit.Framework;
//using Wykop.ApiProvider.Data.ConversationList.PM;
//using Wykop.ApiProvider.DataProviders;
//using Wykop.ApiProvider.Model.Extensions;
//using Wykop.ApiProvider.Model.MessagesRelated;

//namespace Wykop.ApiProvider.UnitTests.Model.Extensions
//{
//    [TestFixture]
//    public class ConversationListExtensionsUnitTests
//    {
//        private Mock<IWykopDataProvider> wykopDataProviderMock;


//        [SetUp]
//        public void SetupTests()
//        {
//            wykopDataProviderMock = new Mock<IWykopDataProvider>();

//            IList<PrivateMessage> privateMessagesListStub = Enumerable.Repeat(new PrivateMessage(), 10).ToList();

//            wykopDataProviderMock.Setup(
//                    x =>
//                        x.GetData<ConversationListRequest, IList<PrivateMessage>>(It.IsAny<ConversationListRequest>(),
//                            It.IsAny<CancellationToken>())
//                            )
//                            .Returns( Task.FromResult(privateMessagesListStub));
//        }

//        [Test]
//        public async Task GetAllMessages_ShouldReturnsPrivateMessagesListForConversationList()
//        {
//            ConversationList conversationList = new ConversationList() {Author = "author"};

//            var pmList = await conversationList.GetAllMessages("testUser", wykopDataProviderMock.Object);

//            Assert.AreEqual(10, pmList.Count);
//            wykopDataProviderMock.Verify(x => x.GetData<ConversationListRequest, IList<PrivateMessage>>(
//                It.IsAny<ConversationListRequest>(),
//                It.IsAny<CancellationToken>()), Times.Once());
//        }
//    }
//}