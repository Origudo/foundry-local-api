using Foundry.Local.Core.Interface;
using Foundry.Local.Core.Models;
using Foundry.Local.Infrastructure.Extensions;
using Microsoft.AI.Foundry.Local;
using System.Runtime.CompilerServices;

namespace Foundry.Local.Infrastructure;

internal class FoundryChatModel(OpenAIChatClient client) : IChatModel
{
    public async IAsyncEnumerable<string> CompleteChatStreamingAsync(
        IEnumerable<ChatMessage> messages,
        [EnumeratorCancellation] CancellationToken ct)
    {
        var sdkMessages = messages.ToFoundryChatMessages();
        var stream = client.CompleteChatStreamingAsync(sdkMessages, ct);

        await foreach (var chunk in stream)
        {
            yield return chunk.Choices[0].Message.Content ?? string.Empty;
        }
    }
}
