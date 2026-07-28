using Foundry.Local.Core.Interface;
using Microsoft.AI.Foundry.Local;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Foundry.Local.Infrastructure;

public class FoundryAIService(IConfiguration configuration, ILogger logger) : IAIService
{
    public IChatModel ChatModel { get; private set; } = default!;

    public async Task InitializeService(CancellationToken ct)
    {
        var config = new Configuration
        {
            AppName = configuration["FoundryService:AppName"] ?? throw new InvalidOperationException("FoundryService:AppName is not configured"),
            LogLevel = Microsoft.AI.Foundry.Local.LogLevel.Information
        };

        await FoundryLocalManager.CreateAsync(config, logger);
        var manager = FoundryLocalManager.Instance;

        await DiscoverEps(manager, ct);

        await LoadModels(manager, ct);
    }

    private async Task LoadModels(FoundryLocalManager manager, CancellationToken ct)
    {
        await LoadChatCompletionModel(manager, ct);
    }

    private async Task LoadChatCompletionModel(FoundryLocalManager manager, CancellationToken ct)
    {
        var catalog = await manager.GetCatalogAsync();
        var chatCompletionModelName = configuration["FoundryService:ChatCompletionModelName"] ?? throw new InvalidOperationException("FoundryService:ChatCompletionModelName is not configured");

        var model = await catalog.GetModelAsync(chatCompletionModelName) ?? throw new Exception("Model not found");

        await model.DownloadAsync(null, ct);
        await model.LoadAsync();

        var client = await model.GetChatClientAsync(ct);
        ChatModel = new FoundryChatModel(client);
    }

    private async Task DiscoverEps(FoundryLocalManager manager, CancellationToken ct)
    {
        var eps = manager.DiscoverEps();

        if (eps.Length > 0)
        {
            await manager.DownloadAndRegisterEpsAsync(ct);
            logger.LogInformation("Execution providers downloaded and registered.");
        }
        else
        {
            logger.LogInformation("No execution providers to download.");
        }
    }
}
