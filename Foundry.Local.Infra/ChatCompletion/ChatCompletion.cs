using Foundry.Local.Core.Interface;
using Foundry.Local.Core.Models;
using System.Text;

namespace Foundry.Local.Infra.ChatCompletion;

public class ChatCompletion(IChatModel chatModel) : IChatCompletion
{
    public async Task<string?> GetChatResponseAsync(IEnumerable<ChatMessage> messages, CancellationToken ct)
    {
        var sb = new StringBuilder();

        await foreach (var content in chatModel.CompleteChatStreamingAsync(messages, ct))
        {
            sb.Append(content);
        }

        return sb.ToString();
    }

    public async IAsyncEnumerable<string> GetChatStreamingResponseAsync(
        IEnumerable<ChatMessage> messages,
        [System.Runtime.CompilerServices.EnumeratorCancellation] CancellationToken ct)
    {
        await foreach (var content in chatModel.CompleteChatStreamingAsync(messages, ct))
        {
            yield return content;
        }
    }
}
