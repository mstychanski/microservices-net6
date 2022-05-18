using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using PaymentService.Domain;

namespace PaymentService.Api.Endpoints
{
    // PM> Install-Package Ardalis.ApiEndpoints
    public class GetPayments : EndpointBaseAsync.WithoutRequest.WithResult<IEnumerable<Payment>>
    {
        private readonly IPaymentRepository _paymentRepository;

        public GetPayments(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }
        
        [HttpGet("api/payments")]
        public async override Task<IEnumerable<Payment>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await _paymentRepository.GetAsync();
        }
    }
}
