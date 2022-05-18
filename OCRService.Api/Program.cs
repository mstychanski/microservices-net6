using Microsoft.Extensions.Primitives;
using OCRService.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


//Logger (Middleware)
//app.Use(async (context, next) =>
//{
//    Console.WriteLine($"{context.Request.Method} {context.Request.Path}");

//    await next.Invoke();

//    Console.WriteLine($"{context.Response.StatusCode}");
//});

//tutaj normalny middleware
app.UseMiddleware<LoggerMiddleware>();
//lub tworz�c interfejs w LoggerMiddleware.cs metod� rozszerzaj�c�
app.UseLogger();


//Kolejno�� podpi�cia middleware ma znaczenie!!!

//Poni�ej spos�b napisania middleware w program.cs
app.Use(async (context, next) =>
{
    if(context.Request.Headers.TryGetValue("Authorization", out StringValues value))
    {
    await next();
    }
    else
    {
        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
    }
});

//tutaj metoda wykonuje si� raz i zamyka program
app.Run(async context =>
{
    if(context.Request.Path == "/api/documents")
    {
        await context.Response.WriteAsync("Hello!");
    }
    else
    {
        context.Response.StatusCode = StatusCodes.Status404NotFound;
    }
});

//ta metoda Run() pozwala na zablokowanie w�tku do wy��czenia hosta 
app.Run();
