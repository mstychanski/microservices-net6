using Bogus;
using CustomerService.Api.AuthenticationHandlers;
using CustomerService.Domain;
using CustomerService.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// MediatR.Extensions.Autofac.DependencyInjection
builder.Services.AddMediatR(typeof(Program));

builder.Services.AddSingleton<ICustomerRepository, FakeCustomerRepository>();
builder.Services.AddSingleton<Faker<Customer>, CustomerFaker>();

builder.Services.AddSingleton<IMessageSender, FakeConsoleMessageSender>();

builder.Services.AddHealthChecks();

var key = Encoding.UTF8.GetBytes("your-256-bit-secret");
//dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = false,
        ValidateAudience = true,
        ValidAudience = "KEPS"
    };
});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Adult",
        policy =>
        {
            policy.RequireAuthenticatedUser();
            policy.RequireClaim(ClaimTypes.DateOfBirth);
            policy.RequireAge(18);
        });
    options.AddPolicy("AccessToFolder",
    policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("Permission");
        policy.RequirePermission("read");
    });
});

builder.Services.AddScoped<IAuthorizationHandler, MinimalAgeHandler>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication(); //Kolejnoœæ jest tutaj wa¿na!!! Autentykacja to sprawdzanie kim ktoœ jest a autoryzacja czy ma dostêp!!!!!
app.UseAuthorization();

app.MapControllers();//.RequireAuthorization(); ///RequireAuthorization() nak³ada na wszystkie controllery [Authorize]

app.MapHealthChecks("/health");
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapGet("api/customers/{id}", async context =>
//    {
//        int id = (int)context.Request.RouteValues["id"];

//        ICustomerRepository customerRepository = context.RequestServices.GetRequiredService<ICustomerRepository>();

//        Customer customer = await customerRepository.Get(id);



//    });
//});

//)

app.Run();
