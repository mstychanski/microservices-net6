using CustomerService.Domain;
using MediatR;

namespace CustomerService.Api.Queries
{
    public record GetCustomersQuery : IRequest<IEnumerable<Customer>>; // marker interface

    public record GetCustomerByIdQuery(int id) : IRequest<Customer>;

    public record GetCustomerByPeselQuery(string pesel) : IRequest<Customer>;
    
}
