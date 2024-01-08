using Mc2.CrudTest.Domain.Contracts.Events.Customer;
using Mc2.CrudTest.Domain.Models.Customers.Exceptions;
using Mc2.CrudTest.Domain.Services;
using Mc2.Framework.Domain;
using Mc2.Framework.Domain.Events;
using Mc2.Framework.Domain.Utils;

namespace Mc2.CrudTest.Domain.Models.Customers;
public class Customer : AggregateRoot<CustomerId>
{
    public Customer(CustomerId entityId, string firstname, string lastname, DateTime dateOfBirth, string phoneNumber,
        string email, string bankAccountNumber, ICustomerDomainService domainService, IClock clock,
        IEventPublisher publisher, long userId) : base(entityId, clock, publisher, userId)
    {
        if (!domainService.EmailIsUnique(email))
            throw new EmailIsNotUniqueException(email);

        EntityId = entityId;
        Firstname = firstname;
        Lastname = lastname;
        DateOfBirth = dateOfBirth;
        PhoneNumber = phoneNumber;
        Email = email;
        BankAccountNumber = bankAccountNumber;
        
        publisher.Publish(new CustomerCreated(EntityId.Id, Firstname, Lastname, DateOfBirth, PhoneNumber,Email,BankAccountNumber));
    }
    
    public string Firstname { get; private set; }
    public string Lastname { get; private set; }
    public DateTime DateOfBirth { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Email { get; private set; }
    public string BankAccountNumber { get; private set; }
}