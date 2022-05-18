using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using PaymentService.Domain;

namespace PaymentService.Api.Endpoints
{
    public class AddPayment : EndpointBaseAsync.WithRequest<Payment>.WithActionResult<Payment>
    {
        private readonly IPaymentRepository paymentRepository;

        public AddPayment(IPaymentRepository paymentRepository)
        {
            this.paymentRepository = paymentRepository;
        }

        [HttpPost("api/payments")]
        public override async Task<ActionResult<Payment>> HandleAsync(Payment payment, CancellationToken cancellationToken = default)
        {
            await paymentRepository.AddAsync(payment);

            return CreatedAtRoute(nameof(GetPaymentById), new { id = payment.Id }, payment);
        }
    }
}
