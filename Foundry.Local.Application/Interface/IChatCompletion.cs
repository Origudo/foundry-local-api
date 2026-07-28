using Foundry.Local.Core.Models;

namespace Foundry.Local.Core.Interface;

public interface IChatCompletion
{
    Task<string?> GetChatResponseAsync(IEnumerable<ChatMessage> messages, CancellationToken ct);
    Task<string?> GetChatStreamingResponseAsync(IEnumerable<ChatMessage> messages, CancellationToken ct);
}
