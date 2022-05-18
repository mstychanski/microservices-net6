namespace OCRService.Api.Middlewares
{

    public static class LoggerMiddlewareExtensions
    {
        public static IApplicationBuilder UseLogger(this IApplicationBuilder app)
        {
            return app.UseMiddleware<LoggerMiddleware>();
        }
    }

    public class LoggerMiddleware
    {
        private readonly RequestDelegate next;

        public LoggerMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            Console.WriteLine($"{context.Request.Method} {context.Request.Path}");

            await next.Invoke(context);

            Console.WriteLine($"{context.Response.StatusCode}");
        }
    }
}
