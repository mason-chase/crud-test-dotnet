using MediatR;

namespace Application.Customers.Commands.UpdateCustomer
{
    public sealed record UpdateCustomerCommand(int Id,string Firstname, string Lastname, DateTime DateOfBirth,
        ulong PhoneNumber, string Email, string BankAccountNumber) : IRequest<bool>;
}