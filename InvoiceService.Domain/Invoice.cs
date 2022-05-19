using Core.Domain;

namespace InvoiceService.Domain
{
    public class Invoice : BaseEntity
    {
        public DateTime CreateDate { get; set; }
        public Customer Customer { get; set; }
        public decimal TotalAmount { get; set; }
    }
}