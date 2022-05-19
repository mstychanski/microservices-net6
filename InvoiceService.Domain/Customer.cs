using Core.Domain;

namespace InvoiceService.Domain
{
    public class Customer : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }   
    }
}