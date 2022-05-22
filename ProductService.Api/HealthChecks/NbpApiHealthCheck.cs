using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;

namespace ProductService.Api.HealthChecks
{

    public class NbpApiHealthCheckOptions
    {
        public string Url { get; set; }
        public string Table { get; set; }
        public TimeSpan Timeout { get; set; }
        public string Format { get; set; }
    }
    public class NbpApiHealthCheck: IHealthCheck
    {
        private const string url = "https://api.nbp.pl/api/exchangerates/tables/a?format=json";

        private readonly IHttpClientFactory httpClientFactory;
        private readonly NbpApiHealthCheckOptions options;

        public NbpApiHealthCheck(IHttpClientFactory httpClientFactory, IOptions<NbpApiHealthCheckOptions> options)
        {
            this.httpClientFactory = httpClientFactory;
            this.options = options.Value;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken)
        {
            string url = $"{options.Url}/api/exchangerates/tables/{options.Table}?format={options.Format}";


            using var client = httpClientFactory.CreateClient(); // bez klamr obiekt ten żyje przez całą metodę. Na końcu wywołuje client.Dispose();

            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return HealthCheckResult.Healthy();
            }
            else
            {
                return HealthCheckResult.Degraded();
            }
        }
    }
}
