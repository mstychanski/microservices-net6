using DeliveryService.Api.Services;
using ProtoBuf.Grpc.Server;

var builder = WebApplication.CreateBuilder(args);

//protobuf-net.Grpc.AspNetCore
builder.Services.AddCodeFirstGrpc();
builder.Services.AddCodeFirstGrpcReflection();

var app = builder.Build();

/* 
 
> dotnet add package System.ServiceModel.Primitives
 
> dotnet grpc-cli ls https://localhost:5081/

> dotnet grpc-cli ls https://localhost:5081/ DeliveryService.Contracts.DeliveryService

> dotnet grpc-cli dump https://localhost:5081/ DeliveryService.Contracts.DeliveryService

*/


app.MapGrpcService<MyDeliveryService>();
app.MapCodeFirstGrpcReflectionService(); 


app.MapGet("/", () => "Hello World!");

app.Run();
