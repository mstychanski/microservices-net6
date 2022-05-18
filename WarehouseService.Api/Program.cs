using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.FileProviders;
using WarehouseService.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.MapGrpcService<MyWarehouseService>();

var provider = new FileExtensionContentTypeProvider();
provider.Mappings.Clear();
provider.Mappings[".proto"] = "text/plain";
app.UseStaticFiles(new StaticFileOptions //Metoda aby wystawiæ plik .proto na swiat. Gdy¿ program nie obs³uguje normalnie plików statycznych. Z jakiegoœ powodu musi byæ ustawiony port inny ni¿ 5061
{
    FileProvider = new PhysicalFileProvider(Path.Combine(app.Environment.ContentRootPath, "Protos")),
    RequestPath = "/proto",
    ContentTypeProvider = provider

});

app.UseDirectoryBrowser(new DirectoryBrowserOptions //Metoda aby wystawiæ plik .proto na swiat. Gdy¿ program nie obs³uguje normalnie plików statycznych
{
    FileProvider = new PhysicalFileProvider(Path.Combine(app.Environment.ContentRootPath, "Protos")),
    RequestPath = "/proto"

});

app.Run();
