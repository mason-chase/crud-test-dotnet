namespace Mc2.CrudTest.Presentation.Shared.Events;

public class CustomerCreatedEvent: EventBase
{
    public CustomerCreatedEvent(Guid id, string firstName, string lastName, string phoneNumber, string email, string bankAccount)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        Email = email;
        BankAccount = bankAccount;
    }
    public Guid Id { get; }
    public string FirstName { get;  }
    public string LastName { get; }
    public string PhoneNumber { get; }
    public string Email { get;}
    public string BankAccount { get; }

    
}

