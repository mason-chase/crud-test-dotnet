using MediatR;
using System.Windows.Input;

namespace Application.Customers.Commands.CreateCustomer;

public sealed record CreateCustomerCommand(string Firstname, string Lastname, DateTime DateOfBirth,
    ulong PhoneNumber, string Email, string BankAccountNumber) : IRequest<int>;
