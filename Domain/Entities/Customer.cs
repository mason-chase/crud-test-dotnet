using Domain.Common;

namespace Domain.Entities;

public class Customer:BaseAuditableEntity
{
    public Customer(string firstName, string lastName, DateTime dateOfBirth,
        ulong phoneNumber,string email, string bankAccountNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        PhoneNumber = phoneNumber;
        Email = email;
        BankAccountNumber = bankAccountNumber;
            
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }    
    public DateTime DateOfBirth { get; private set; }
    public ulong PhoneNumber { get; private set; }
    public string Email { get; private set; }   
    public string BankAccountNumber { get; private set; }


}
