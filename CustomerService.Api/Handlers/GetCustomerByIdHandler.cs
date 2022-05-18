using CustomerService.Api.Queries;
using CustomerService.Domain;
using MediatR;

namespace CustomerService.Api.Handlers
{
    public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdQuery, Customer>
    {
        private readonly ICustomerRepository customerRepository;

        public GetCustomerByIdHandler(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public async Task<Customer> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            return await customerRepository.GetAsync(request.id);
        }
    }
}
