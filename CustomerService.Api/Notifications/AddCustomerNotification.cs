using CustomerService.Domain;
using MediatR;

namespace CustomerService.Api.Notifications
{    
    public record AddCustomerNotification(Customer Customer) : INotification; // marker interface
}
