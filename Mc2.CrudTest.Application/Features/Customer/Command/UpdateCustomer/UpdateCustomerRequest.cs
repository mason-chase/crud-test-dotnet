using Mc2.CrudTest.Domain.Models;
using MediatR;

namespace Mc2.CrudTest.Application.Features.Customer.Command.UpdateCustomer;

public class UpdateCustomerRequest : IRequest<CustomerModel>
{
    public string Id { get; set; }
    public string FirstName { get; set;}
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string BankAccountNumber { get; set; }
    public DateTime DateOfBirth { get; set; }

}