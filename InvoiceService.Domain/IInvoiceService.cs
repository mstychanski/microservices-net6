using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceService.Domain
{
    public interface IInvoiceService
    {
        Task CreateInvoice(int customerId);
        Task<Invoice> Get(int customerId);
    }
}
