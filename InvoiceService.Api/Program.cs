using Hangfire;
using InvoiceService.Domain;
using InvoiceService.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IInvoiceService, PdfInvoiceService>();

builder.Services.AddHttpClient();

//dotnet add package Hangfire.AspNetCore
//dotnet add package Hangfire.InMemory

string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

builder.Services.AddHangfire(options => options.UseInMemoryStorage()); //InMemory
builder.Services.AddHangfire(options => options.UseSqlServerStorage(connString));

builder.Services.AddHangfireServer();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("api/customers/{id}/invoice", async (int id,
    IInvoiceService invoiceService,
    IBackgroundJobClient jobClient) =>
{
    // Metoda statyczna (nie jest zalecana) bo jest nietestowalna
    //BackgroundJob.Enqueue( () => invoiceService.CreateInvoice(id)); 

    //wersja instancyjna, testowalna
    var jobId = jobClient.Enqueue( () => invoiceService.CreateInvoice(id));

    return Results.Accepted();
});

app.MapHangfireDashboard();

app.Run();
