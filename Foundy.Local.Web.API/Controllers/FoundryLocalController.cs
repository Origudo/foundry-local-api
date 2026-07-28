using Foundry.Local.Core.Interface;
using Foundry.Local.Core.Models;
using Foundy.Local.Web.API.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Foundy.Local.Web.API.Controllers;

[Route("api")]
[ApiController]
public class FoundryLocalController() : ControllerBase
{
    [HttpPost("chat/completion")]
    public async Task<IActionResult> CompleteChatAsync(
        [FromBody] ChatCompletionRequest request,
        [FromServices] IChatCompletion chatCompletion,
        CancellationToken ct)
    {
        var response = await chatCompletion.GetChatResponseAsync(
            request.Messages,
            ct);

        return Ok(new ChatCompletionResponse
        {
            Content = response ?? string.Empty
        });
    }
}
