// See https://aka.ms/new-console-template for more information
using Bogus;
using Grpc.Core;
using Grpc.Net.Client;
using WarehouseService.Api;

Console.WriteLine("Hello, gRPC Client!");

const string url = "https://localhost:5071";

using var channel = GrpcChannel.ForAddress(url);

var client = new WarehouseService.Api.WarehouseService.WarehouseServiceClient(channel);

var request = new WarehouseService.Api.GetWarehouseStateRequest { WarehouseId = 1, ProductId = 10 };

var response = await client.GetWarehouseStateAsync(request);

Console.WriteLine($"{response.IsAvailable} {response.Quantity}");

var incrementRequests = new Faker<IncrementWarehouseStateRequest>()
    .RuleFor(p => p.ProductId, f => f.Random.Int(1, 10))
    .RuleFor(p => p.WarehouseId, f => 1)
    .RuleFor(p => p.Quantity, f => f.Random.Int(1, 20))
    .GenerateLazy(100);

var stream = client.IncrementWarehouseState().RequestStream;

foreach (IncrementWarehouseStateRequest incrementRequest in incrementRequests)
{
    Console.WriteLine($"Sending... {incrementRequest.WarehouseId} {incrementRequest.ProductId} {incrementRequest.Quantity}");
    await stream.WriteAsync(incrementRequest);
    await Task.Delay(TimeSpan.FromSeconds(0.1));
}

Console.WriteLine("Waiting...");

var subscribeRequest = new SubscribeWarehouseStateRequest { ProductId = 10, LimitQuantity = 100 };
var subscription = client.SubscribeWarehouseState(subscribeRequest);

var stateResponses = subscription.ResponseStream.ReadAllAsync();

await foreach(var stateResponse in stateResponses)
{
    Console.WriteLine($"{stateResponse.IsAvailable} {stateResponse.Quantity}");
}


Console.WriteLine("Press any key to exit...");
Console.ReadKey();
