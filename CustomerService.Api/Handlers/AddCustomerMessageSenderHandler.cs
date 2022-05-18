using CustomerService.Api.Notifications;
using CustomerService.Domain;
using MediatR;

namespace CustomerService.Api.Handlers
{
    public class AddCustomerMessageSenderHandler : INotificationHandler<AddCustomerNotification>
    {
        private readonly IMessageSender messageSender;

        public AddCustomerMessageSenderHandler(IMessageSender messageSender)
        {
            this.messageSender = messageSender;
        }

        public async Task Handle(AddCustomerNotification notification, CancellationToken cancellationToken)
        {
            var customer = notification.Customer;

            await messageSender.Send(customer.Email, "Welcome!");
        }
    }
}
