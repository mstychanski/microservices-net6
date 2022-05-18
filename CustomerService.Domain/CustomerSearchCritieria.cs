using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.Domain
{
    
    public class CustomerSearchCritieria : SearchCriteria
    {
        public string? Pesel { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
    }
}
