using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using PaymentService.Domain;

namespace PaymentService.Api.Endpoints
{
    public class GetPaymentById : EndpointBaseAsync.WithRequest<int>.WithActionResult<Payment>
    {
        private readonly IPaymentRepository paymentRepository;

        public GetPaymentById(IPaymentRepository paymentRepository)
        {
            this.paymentRepository = paymentRepository;
        }

        [HttpGet("api/payments/{id}", Name = nameof(GetPaymentById))]
        public async override Task<ActionResult<Payment>> HandleAsync(int id, CancellationToken cancellationToken = default)
        {
            return await paymentRepository.GetAsync(id);
        }
    }
}
