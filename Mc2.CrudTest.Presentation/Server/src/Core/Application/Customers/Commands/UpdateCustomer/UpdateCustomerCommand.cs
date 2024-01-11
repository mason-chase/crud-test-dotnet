using MediatR;

namespace Application.Customers.Commands.UpdateCustomer
{
    public sealed record UpdateCustomerCommand(int Id,string Firstname, string Lastname, DateTime DateOfBirth,
        string PhoneNumber, string Email, string BankAccountNumber) : IRequest<bool>;
}