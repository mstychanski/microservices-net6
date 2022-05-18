using CustomerService.Api.Queries;
using CustomerService.Domain;
using MediatR;

namespace CustomerService.Api.Handlers
{
    public class GetCustomerByPeselHandler : IRequestHandler<GetCustomerByPeselQuery, Customer>
    {
        private readonly ICustomerRepository customerRepository;

        public GetCustomerByPeselHandler(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public async Task<Customer> Handle(GetCustomerByPeselQuery request, CancellationToken cancellationToken)
        {
            return await customerRepository.GetAsync(request.pesel);
        }
    }
}
