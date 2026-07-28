using Foundry.Local.Core.Interface;
using Foundry.Local.Infra.ChatCompletion;
using Foundry.Local.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton(sp =>
    sp.GetRequiredService<ILoggerFactory>().CreateLogger("Foundry"));

builder.Services.AddSingleton<FoundryAIService>();
builder.Services.AddSingleton<IAIService>(sp => sp.GetRequiredService<FoundryAIService>());
builder.Services.AddSingleton(sp => sp.GetRequiredService<FoundryAIService>().ChatModel);
builder.Services.AddSingleton<IChatCompletion, ChatCompletion>();

var app = builder.Build();

// Initialize Foundry
var aiService = app.Services.GetRequiredService<IAIService>();
await aiService.InitializeService(CancellationToken.None);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
