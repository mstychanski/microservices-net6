using Core.Domain;

namespace PaymentService.Domain
{
    public interface IPaymentRepository : IEntityRepository<int, Payment>
    {

    }
}