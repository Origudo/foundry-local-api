using Betalgo.Ranul.OpenAI.ObjectModels.RequestModels;

namespace Foundry.Local.Infrastructure.Extensions;

internal static class ChatMessageExtensions
{
    public static List<ChatMessage> ToFoundryChatMessages(
        this IEnumerable<Core.Models.ChatMessage> messages)
    {
        return messages
            .Select(message => new ChatMessage { Role = "user", Content = message.Content })
            .Cast<ChatMessage>()
            .ToList();
    }
}