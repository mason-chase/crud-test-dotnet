namespace Mc2.CrudTest.Domain.Entities;

public class Customer
{
    public long Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public DateOnly DateOfBirth { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Email { get; private set; }
    public string BankAccount { get; private set; }


    public static Customer New(long id, string firstName, string lastName,
        DateOnly dateOfBirth, string phoneNumber, string email, string bankAccount)
    {
        return new Customer
        {
            Id = id,
            FirstName = firstName.Trim(),
            LastName = lastName.Trim(),
            DateOfBirth = dateOfBirth,
            PhoneNumber = phoneNumber.Trim(),
            Email = email.Trim(),
            BankAccount = bankAccount.Trim()
        };
    }

    public void Edit(string firstName, string lastName,
        DateOnly dateOfBirth, string phoneNumber, string email, string bankAccount)
    {
        FirstName = firstName.Trim();
        LastName = lastName.Trim();
        DateOfBirth = dateOfBirth;
        PhoneNumber = phoneNumber.Trim();
        Email = email.Trim();
        BankAccount = bankAccount.Trim();
    }

}
