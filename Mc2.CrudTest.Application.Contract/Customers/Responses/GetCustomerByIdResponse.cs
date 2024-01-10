namespace Mc2.CrudTest.Application.Contract.Customers.Responses;

public class GetCustomerByIdResponse
{
    public Guid Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string BankAccountNumber { get; set; }
    public string Fullname { get; set; }
}
