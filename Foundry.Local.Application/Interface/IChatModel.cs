using Foundry.Local.Core.Models;

namespace Foundry.Local.Core.Interface;

public interface IChatModel
{
    IAsyncEnumerable<string> CompleteChatStreamingAsync(
        IEnumerable<ChatMessage> messages, CancellationToken ct);
}
