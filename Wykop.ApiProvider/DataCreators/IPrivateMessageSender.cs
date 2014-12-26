using System.Threading;
using System.Threading.Tasks;
using Wykop.ApiProvider.Model.Operations;

namespace Wykop.ApiProvider.DataCreators
{
    public interface IPrivateMessageSender
    {
        Task<PrivateMessageSendResult> SendMessage(PrivateMessageContent messageContent, CancellationToken cancellationToken);
    }
}