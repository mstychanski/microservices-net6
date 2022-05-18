using CustomerService.Api.Notifications;
using CustomerService.Domain;
using MediatR;

namespace CustomerService.Api.Handlers
{
    public class AddCustomerToRepository : INotificationHandler<AddCustomerNotification>
    {
        private readonly ICustomerRepository customerRepository;

        public AddCustomerToRepository(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public async Task Handle(AddCustomerNotification notification, CancellationToken cancellationToken)
        {
            await customerRepository.AddAsync(notification.Customer);
        }
    }
}
