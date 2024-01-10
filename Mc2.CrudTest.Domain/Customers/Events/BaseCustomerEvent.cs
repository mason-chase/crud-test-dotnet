using Mc2.CrudTest.Core;

namespace Mc2.CrudTest.Domain.Customers.Events;

public class BaseCustomerEvent : BaseEvent
{
    public Guid Id { get; set; }
    public string Firstname { get; }
    public string Lastname { get; }
    public DateTime DateOfBirth { get; }
    public string PhoneNumber { get; }
    public string Email { get; }
    public string BankAccountNumber { get; }

    public BaseCustomerEvent(
        Guid id,
        string firstname,
        string lastname,
        DateTime dateOfBirth,
        string phoneNumber,
        string email,
        string bankAccountNumber)
    {
        Id = id;
        Firstname = firstname;
        Lastname = lastname;
        DateOfBirth = dateOfBirth;
        PhoneNumber = phoneNumber;
        Email = email;
        BankAccountNumber = bankAccountNumber;
    }
}
