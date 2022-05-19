
using InvoiceService.Domain;

namespace InvoiceService.Infrastructure
{
    public class PdfInvoiceService : IInvoiceService
    {
        private Invoice invoice;
        public async Task CreateInvoice(int customerId)
        {
            this.invoice = new Invoice
            {
                CreateDate = DateTime.Now,
                Customer = new Customer { Id = customerId, FirstName = "John", LastName = "Smith" }
            };

            Console.WriteLine("calculating...");

            await Task.Delay(TimeSpan.FromSeconds(30));

            invoice.TotalAmount = 1000;
        }

        public async Task<Invoice> Get(int id)
        {
            return invoice;
        }
    }
}