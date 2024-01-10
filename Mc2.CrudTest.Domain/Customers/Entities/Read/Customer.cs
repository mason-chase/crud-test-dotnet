using Mc2.CrudTest.Core;

namespace Mc2.CrudTest.Domain.Customers.Entities.Read;

public class Customer : IEntity<Guid>
{
    public Guid Id { get; private set; }
    public string Firstname { get; private set; }
    public string Lastname { get; private set; }
    public DateTime DateOfBirth { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Email { get; private set; }
    public string BankAccountNumber { get; private set; }
    public string Fullname { get; private set; }

    public Customer()
    {
    }

    public Customer(
        Guid id,
        string firstname,
        string lastname,
        DateTime dateOfBirth,
        string phoneNumber,
        string email,
        string bankAccountNumber,
        string fullname)
    {
        Id = id;
        Firstname = firstname;
        Lastname = lastname;
        DateOfBirth = dateOfBirth;
        PhoneNumber = phoneNumber;
        Email = email;
        BankAccountNumber = bankAccountNumber;
        Fullname = fullname;
    }
}
