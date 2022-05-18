using Core.Domain;

namespace PaymentService.Domain
{
    public class Payment : BaseEntity
    {
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
    }
}