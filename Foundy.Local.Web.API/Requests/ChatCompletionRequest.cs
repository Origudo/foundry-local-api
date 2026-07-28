using Foundry.Local.Core.Models;

namespace Foundy.Local.Web.API.Responses;

public sealed class ChatCompletionRequest
{
    public List<ChatMessage> Messages { get; init; } = [];
}
