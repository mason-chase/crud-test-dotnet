using MediatR;

namespace Application.Customers.Commands.CreateCustomer;

public class CustomerCreatedEvent : INotification
{
    public int CustomerId { get; }

    public CustomerCreatedEvent(int customerId)
    {
        CustomerId = customerId;
    }
}