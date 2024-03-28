using Mc2.CrudTest.Contracts;

namespace Mc2.CrudTest.Application.UseCases.Customer.Queries;

public class GetAllCustomer : IQuery<string?, List<CustomerResponse>>
{
    public Task<List<CustomerResponse>> Execute(string? filter)
    {
        throw new NotImplementedException();
    }
}