using TrackingService.Api.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();

var app = builder.Build();

app.MapGet("/", () => "Use signal-R on signalr/messages");

app.MapHub<MessagesHub>("signalr/messages");

app.Run();
