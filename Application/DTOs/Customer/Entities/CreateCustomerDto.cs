namespace Application.DTOs.Customer.Entities;

public class CreateCustomerDto
{
    public CreateCustomerDto()
    {
            
    }
    public CreateCustomerDto(string firstName, string lastName, DateTime dateOfBirth,
        ulong phoneNumber, string email, string bankAccountNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        PhoneNumber = phoneNumber;
        Email = email;
        BankAccountNumber = bankAccountNumber;

    }

    public string FirstName { get; set; } = null!;
    public string LastName { get; set; }=null!;
    public DateTime DateOfBirth { get; set; }
    public ulong PhoneNumber { get; set; }
    public string Email { get; set; }
    public string BankAccountNumber { get; set; }
}
