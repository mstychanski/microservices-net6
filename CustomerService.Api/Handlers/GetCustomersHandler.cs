using CustomerService.Api.Queries;
using CustomerService.Domain;
using MediatR;

namespace CustomerService.Api.Handlers
{
    public class GetCustomersHandler : IRequestHandler<GetCustomersQuery, IEnumerable<Customer>>
    {
        private readonly ICustomerRepository customerRepository;

        public GetCustomersHandler(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public async Task<IEnumerable<Customer>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            return await customerRepository.GetAsync();
        }
    }
}
