using AuthService.Domain;
using AuthService.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("api/toen/create", async (AuthModel model, IAuthService authService) =>
{
    if (await authService.TryAuthorizeAsync(model.Login, model.Password, out User user))
    {
        // TODO: generate token
        throw new NotImplementedException();

        string token = "";

        return Results.Ok(token);
    }
    else
    {
        return Results.BadRequest(new { message = "Username or password is incorrect." });
    }
});

app.Run();
