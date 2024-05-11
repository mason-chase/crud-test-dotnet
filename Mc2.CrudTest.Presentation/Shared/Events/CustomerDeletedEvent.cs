namespace Mc2.CrudTest.Presentation.Shared.Events;

public class CustomerDeletedEvent: EventBase
{
    public Guid CustomerId { get; }

    public CustomerDeletedEvent(Guid customerId)
    {
        CustomerId = customerId;
    }
    
}