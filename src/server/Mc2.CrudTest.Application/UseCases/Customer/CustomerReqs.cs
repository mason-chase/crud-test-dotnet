using MediatR;

namespace Mc2.CrudTest.Application.UseCases.Customer;

public class CreateCustomerReq : IRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string BankAccountNumber { get; set; }
}

public class UpdateCustomerReq : IRequest<Domain.Entities.Customer>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string BankAccountNumber { get; set; }
}

public class RemoveCustomerReq : IRequest
{
    public int CustomerId { get; set; }
}

public class GetCustomerByIdReq : IRequest<Domain.Entities.Customer>
{
    public int CustomerId { get; set; }
}

public class GetAllCustomerReq : IRequest<List<Domain.Entities.Customer>> { }