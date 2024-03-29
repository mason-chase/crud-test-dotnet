using MediatR;

namespace Mc2.CrudTest.Application.Commands.Customer;

public class CreateCustomerCommand : IRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public ulong PhoneNumber { get; set; }
    public string Email { get; set; }
    public string BankAccountNumber { get; set; }
}

public class UpdateCustomerCommand : IRequest
{
    public int CustomerId { get; set; }
    public ulong PhoneNumber { get; set; }
    public string Email { get; set; }
    public string BankAccountNumber { get; set; }
}

public class RemoveCustomerCommand : IRequest
{
    public int CustomerId { get; set; }
}

public class GetCustomerByIdQuery : IRequest<Domain.Entities.Customer>
{
    public int CustomerId { get; set; }
}

public class GetAllCustomerQuery : IRequest<List<Domain.Entities.Customer>> { }