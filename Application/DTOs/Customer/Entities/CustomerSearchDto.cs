namespace Application.DTOs.Customer.Entities;

public class CustomerSearchDto
{
    public string Name { get; set; } 
    public DateTime? DateOfBirth { get; set; }
    public ulong? PhoneNumber { get; set; }
    public string Email { get; set; }
}
