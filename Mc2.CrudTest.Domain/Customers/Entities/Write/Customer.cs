using Mc2.CrudTest.Core;
using Mc2.CrudTest.Domain.Customers.Events;

namespace Mc2.CrudTest.Domain.Customers.Entities.Write;

public class Customer : BaseEntity, IAggregateRoot
{
    private bool _isDeleted;

    public string Firstname { get; private set; }
    public string Lastname { get; private set; }
    public DateTime DateOfBirth { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Email { get; private set; }
    public string BankAccountNumber { get; private set; }

    public Customer()
    {
    }

    public Customer(
        string firstname,
        string lastname,
        DateTime dateOfBirth,
        string phoneNumber,
        string email,
        string bankAccountNumber)
    {
        Firstname = firstname;
        Lastname = lastname;
        DateOfBirth = dateOfBirth;
        PhoneNumber = phoneNumber;
        Email = email;
        BankAccountNumber = bankAccountNumber;

        AddDomainEvent(new CustomerCreatedEvent(Id, firstname, lastname, dateOfBirth, phoneNumber, email, bankAccountNumber));
    }

    public void ChangeEmail(string newEmail)
    {
        if (Email.Equals(newEmail, StringComparison.InvariantCultureIgnoreCase))
        {
            return;
        }

        Email = newEmail;

        AddDomainEvent(new CustomerUpdatedEvent(Id, Firstname, Lastname, DateOfBirth, PhoneNumber, newEmail, BankAccountNumber));
    }

    public void Delete()
    {
        if (_isDeleted)
        {
            return;
        }

        _isDeleted = true;
        AddDomainEvent(new CustomerDeletedEvent(Id, Firstname, Lastname, DateOfBirth, PhoneNumber, Email, BankAccountNumber));
    }
}
