using Mc2.CrudTest.Application.Common.Models;
using MediatR;

namespace Mc2.CrudTest.Application.Commands;

public class UpdateCustomerCommand : IRequest<bool>
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string BankAccountNumber { get; set; }
}