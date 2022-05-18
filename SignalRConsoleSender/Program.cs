
using Bogus;
using Microsoft.AspNetCore.SignalR.Client;
using TrackingService.Domain;

Console.WriteLine("Hello, Signal-R Sender!");

//Microsoft.AspNetCore.SignalR.Client

const string url = "https://localhost:5051/signalr/messages";

HubConnection connection = new HubConnectionBuilder()
    .WithUrl(url)
    .WithAutomaticReconnect()
    .Build();   

Console.WriteLine($"Connecting... {url}");
await connection.StartAsync();
Console.WriteLine($"Connected. {connection.ConnectionId}");

var messages = new Faker<Message>()
    .RuleFor(p => p.Title, f => f.Lorem.Sentence())
    .RuleFor(p => p.Content, f => f.Lorem.Paragraph())
    .GenerateForever();


foreach (var message in messages)
{
    Console.WriteLine($"{message.Title}: {message.Content}");
    await connection.SendAsync("SendMessage", message);
    Console.WriteLine("Sent.");

    await Task.Delay(10);
}