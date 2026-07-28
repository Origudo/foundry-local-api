namespace Foundry.Local.Core.Interface;

public interface IAIService
{
    IChatModel ChatModel { get; }
    Task InitializeService(CancellationToken ct);
}
