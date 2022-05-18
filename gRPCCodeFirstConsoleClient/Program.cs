// See https://aka.ms/new-console-template for more information
using DeliveryService.Contracts;
using Grpc.Net.Client;
using ProtoBuf;
using ProtoBuf.Grpc.Client;

Console.WriteLine("Hello, gRPC Code-First!");

//dotnet add package Grpc.Net.Client
//dotnet add package protobuf-net.Grpc

const string url = "https://localhost:5081";

using var channel = GrpcChannel.ForAddress(url);
var client = channel.CreateGrpcService<IDeliveryService>();

var request = new DeliveryRequest { DeliveryId = 100, DeliveryDate = DateTime.Now, Sign = "John" };
await client.ConfirmDeliveryAsync(request);

string proto = Serializer.GetProto<IDeliveryService>();
Console.WriteLine(proto);

Console.WriteLine("Press any key to exit.");
Console.ReadKey();
