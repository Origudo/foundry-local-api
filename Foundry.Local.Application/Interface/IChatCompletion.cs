using Foundry.Local.Core.Models;

namespace Foundry.Local.Core.Interface;

public interface IChatCompletion
{
    Task<string?> GetChatResponseAsync(IEnumerable<ChatMessage> messages, CancellationToken ct);
    IAsyncEnumerable<string> GetChatStreamingResponseAsync(IEnumerable<ChatMessage> messages, CancellationToken ct);
}
