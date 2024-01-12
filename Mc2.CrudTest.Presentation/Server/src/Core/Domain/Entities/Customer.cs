namespace Domain.Entities;

public class Customer
{
    public int Id { get; set; }

    public string Firstname { get; set; }=string.Empty;
    public string Lastname { get; set; }=string.Empty;
    public DateTime DateOfBirth { get; set; }
    public ulong PhoneNumber { get; set; } 
    public string Email { get; set; } = string.Empty;
    public string BankAccountNumber { get; set; } = string.Empty;
}