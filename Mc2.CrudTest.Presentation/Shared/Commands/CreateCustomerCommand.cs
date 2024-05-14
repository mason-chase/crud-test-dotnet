using MediatR;

namespace Mc2.CrudTest.Presentation.Shared.Commands;

public class CreateCustomerCommand: IRequest {
    public Guid CustomerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string BankAccount { get; set; }
}