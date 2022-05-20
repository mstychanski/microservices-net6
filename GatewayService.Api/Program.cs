var builder = WebApplication.CreateBuilder(args);

builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));
var app = builder.Build();


//dotnet add package Yarp.ReverseProxy
app.MapGet("/", () => "Hello Gateway Api!!");


app.MapReverseProxy();

app.Run();
