namespace Mc2.CrudTest.Domain.Customers.Events;

public class CustomerUpdatedEvent : BaseCustomerEvent
{
    public CustomerUpdatedEvent(
        Guid id,
        string firstname,
        string lastname,
        DateTime dateOfBirth,
        string phoneNumber,
        string email,
        string bankAccountNumber) : base(
            id,
            firstname,
            lastname,
            dateOfBirth,
            phoneNumber,
            email,
            bankAccountNumber)
    {
        MessageType = nameof(CustomerUpdatedEvent);
    }
}
