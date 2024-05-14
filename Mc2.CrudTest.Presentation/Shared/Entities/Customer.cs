using Mc2.CrudTest.Presentation.Shared.Events;
using Mc2.CrudTest.Presentation.Shared.ValueObjects;

namespace Mc2.CrudTest.Presentation.Shared.Entities{
public class Customer {
	public Guid Id { get; private set; }
    public Name FirstName { get; private set; }
    public Name LastName { get; private set; }
    public BankAccount BankAccount { get; private set; }
    public DateOfBirth DateOfBirth { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
    public Email Email { get; private set; }
    public bool IsDeleted { get; }

    // Constructor for rehydration
    public Customer(Guid id, string firstName, string lastName, string phoneNumber, string email, string bankAccount)
    {
        Id = id;
        FirstName = new Name(firstName) ?? throw new ArgumentNullException(nameof(firstName));
        LastName = new Name(lastName) ?? throw new ArgumentNullException(nameof(lastName));
        PhoneNumber = new PhoneNumber(phoneNumber) ?? throw new ArgumentNullException(nameof(phoneNumber));
        Email = new Email(email) ?? throw new ArgumentNullException(nameof(email));
        BankAccount = new BankAccount(bankAccount) ?? throw new ArgumentException(bankAccount);
        IsDeleted = false;
    }

    
    public Customer(string firstName, string lastName, string phoneNumber, string email, string bankAccount)
    {
        FirstName = new Name(firstName) ?? throw new ArgumentNullException(nameof(firstName));
        LastName = new Name(lastName) ?? throw new ArgumentNullException(nameof(lastName));
        PhoneNumber = new PhoneNumber(phoneNumber) ?? throw new ArgumentNullException(nameof(phoneNumber));
        Email = new Email(email) ?? throw new ArgumentNullException(nameof(email));
        BankAccount = new BankAccount(bankAccount) ?? throw new ArgumentException(bankAccount);
        IsDeleted = false;
    }

    public Customer()
    {
        
    }


    public static Customer Create(string firstName, string lastName, string phoneNumber, string email, string bankAccount)
    {
        var customer = new Customer(firstName:firstName, lastName: lastName, phoneNumber:phoneNumber, email, bankAccount);
        customer.Apply(new CustomerCreatedEvent(customer.Id, firstName, lastName,phoneNumber, email, bankAccount));
        return customer;
    }

    public static void Delete(Guid id)
    {
        // remove customer form store
    }

    public static void Update(Guid id, string firstName, string lastName, string phoneNumber, string email,
        string bankAccount)
    {
        // update customer with CustomerId == id
    }
    // Apply methods
    protected void Apply(CustomerCreatedEvent @event)
    {
        Id = @event.Id;
        FirstName = new Name(@event.FirstName);
        LastName = new Name(@event.LastName);
        Email = new Email(@event.Email);
        PhoneNumber = new PhoneNumber(@event.PhoneNumber);
        BankAccount = new BankAccount(@event.BankAccount);
       
    }

    protected void Apply(CustomerUpdatedEvent @event)
    {
        FirstName = new Name(@event.FirstName);
        LastName = new Name(@event.LastName);
        Email = new Email(@event.Email);
        PhoneNumber = new PhoneNumber(@event.PhoneNumber);
        BankAccount = new BankAccount(@event.BankAccount);
        Id = @event.CustomerId;

    }

    protected void Apply(CustomerDeletedEvent @event)
    {
        Id = @event.AggregateId;
    }
    
    
    // Method to apply events generically
    public void Apply(object @event)
    {
        ((dynamic)this).Apply((dynamic)@event);
    }
   
    
    public Customer Rehydrate(IEnumerable<EventBase> events)
    {
        var customer = new Customer();
        foreach (var @event in events)
        {
            customer.Apply(@event);
        }
        return customer;
    }
}
}