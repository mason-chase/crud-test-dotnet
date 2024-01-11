using MediatR;

namespace Application.Customers.Commands.CreateCustomer;

public class CustomerCreatedEventHandler : INotificationHandler<CustomerCreatedEvent>
{
    public Task Handle(CustomerCreatedEvent notification, CancellationToken cancellationToken)
    {

        return Task.CompletedTask;
    }
}
