using DeliveryService.Contracts;
using ProtoBuf.Grpc;

namespace DeliveryService.Api.Services
{
    public class MyDeliveryService : IDeliveryService
    {
        public Task<DeliveryResponse> ConfirmDeliveryAsync(DeliveryRequest request, CallContext context = default)
        {
            var response = new DeliveryResponse
            {
                Conirmed = true
            };
            return Task.FromResult(response);
        }
    }
}
