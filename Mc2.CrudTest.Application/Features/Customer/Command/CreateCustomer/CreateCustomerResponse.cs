using Mc2.CrudTest.Domain.Models;

namespace Mc2.CrudTest.Application.Features.Customer.Command.CreateCustomer;

public class CreateCustomerResponse : BaseModel
{
    public string Id { get; set; }
    public string FirstName { get; set;}
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string BankAccountNumber { get; set; }
    
}