using Bogus;
using PaymentService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Infrastructure
{
    public class PaymentFaker : Faker<Payment>
    {
        public PaymentFaker()
        {
            RuleFor(p => p.Id, f => f.IndexFaker);
            RuleFor(p => p.PaymentDate, f => f.Date.Past());
            RuleFor(p => p.Amount, f => decimal.Parse( f.Commerce.Price()));
        }
    }
}
