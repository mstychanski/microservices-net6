using ShoppingCartService.Domain;
using ShoppingCartService.Infrastructure;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect("localhost"));
builder.Services.AddScoped<IShoppingCartService, RedisShoppingCartService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () => "Hello ShoppingCart !");

app.MapPost("api/cart/{sessionId}", async (Guid sessionId, Detail detail, IShoppingCartService shoppingCartService) =>
{
    await shoppingCartService.Add(sessionId, detail);

    return Results.Ok();
});

app.MapDelete("api/cart/{sessionId}/{productId}", async (Guid sessionId, int productId, IShoppingCartService shoppingCartService) =>
{
    await shoppingCartService.Remove(sessionId, productId);

    return Results.Ok();
});

app.UseHttpsRedirection();

app.Run();
