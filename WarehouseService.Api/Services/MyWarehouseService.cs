using Bogus;
using Grpc.Core;

namespace WarehouseService.Api.Services
{

    //TODO Stworzyć repository oraz base entity itp.
    public class MyWarehouseService :   WarehouseService.WarehouseServiceBase //nazwa Mywarehousrservice po to aby nie było konfliktów 
    {
        private readonly ILogger<MyWarehouseService> logger;

        public MyWarehouseService(ILogger<MyWarehouseService> logger)
        {
            this.logger = logger;
        }

        public override Task<GetWarehouseStateResponse> GetWarehouseState(GetWarehouseStateRequest request, ServerCallContext context)
        {
            logger.LogInformation($"Request for availability of Product no.{request.ProductId} for warheouse {request.WarehouseId}.");
            var result = new GetWarehouseStateResponse
            {
                IsAvailable = true,
                Quantity = 100
            };

            return Task.FromResult(result);
        }

        public override async Task<IncrementWarehouseStateResponse> IncrementWarehouseState(IAsyncStreamReader<IncrementWarehouseStateRequest> requestStream, ServerCallContext context)
        {
            await foreach (var request in requestStream.ReadAllAsync())
            {

                logger.LogInformation("Increment Product: {ProductId} Avalability: {Quantity}", request.ProductId, request.Quantity);

                await Task.Delay(500);
            }
            var response = new IncrementWarehouseStateResponse { IsConfirmed = true };

            return response;
        }


        public override async Task SubscribeWarehouseState(SubscribeWarehouseStateRequest request, IServerStreamWriter<GetWarehouseStateResponse> responseStream, ServerCallContext context)
        {
            var responses = new Faker<GetWarehouseStateResponse>()
                .RuleFor(p => p.Quantity, f => f.Random.Int(0, 100))
                .RuleFor(p => p.IsAvailable, (f, x) => x.Quantity > 0)
                .GenerateForever();

                foreach (var response in responses)
                {
                    await responseStream.WriteAsync(response);
                    await Task.Delay(TimeSpan.FromSeconds(5));
                }
        }
    }
}
