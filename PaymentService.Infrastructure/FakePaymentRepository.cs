using Bogus;
using Core.Intrastructure;
using PaymentService.Domain;

namespace PaymentService.Infrastructure
{
    public class FakePaymentRepository : FakeEntityRepository<int, Payment>, IPaymentRepository
    {
        public FakePaymentRepository(Faker<Payment> faker) : base(faker)
        {
        }
    }
}