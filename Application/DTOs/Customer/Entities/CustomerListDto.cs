namespace Application.DTOs.Customer.Entities;

public class CustomerListDto:BaseDto
{
    public string FullName { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public ulong PhoneNumber { get; set; }
    public string Email { get; set; }
    public string BankAccountNumber { get; set; }
}
