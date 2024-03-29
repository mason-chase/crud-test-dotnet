namespace Mc2.CrudTest.Application.DTOs;

public class CustomerCreateDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public ulong PhoneNumber { get; set; }
    public string Email { get; set; }
    public string BankAccountNumber { get; set; }
}

public class CustomerUpdateDTO
{
    public ulong PhoneNumber { get; set; }
    public string Email { get; set; }
    public string BankAccountNumber { get; set; }

}

