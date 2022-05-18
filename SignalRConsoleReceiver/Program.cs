
using Microsoft.AspNetCore.SignalR.Client;
using TrackingService.Domain;

Console.WriteLine("Hello, Signal-R Receiver!");

//Microsoft.AspNetCore.SignalR.Client

const string url = "https://localhost:5051/signalr/messages";

HubConnection connection = new HubConnectionBuilder()
    .WithUrl(url)
    .WithAutomaticReconnect()
    .Build();


connection.On<Message>("YouHaveGotMessage", message => Console.WriteLine($"{message.Title}: {message.Content}"));


Console.WriteLine($"Connecting... {url}");
await connection.StartAsync();
Console.WriteLine($"Connected. {connection.ConnectionId}");


Console.WriteLine("Press any key to exit.");
Console.ReadKey();

await connection.StopAsync();
