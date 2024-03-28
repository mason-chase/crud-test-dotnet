using Mc2.CrudTest.Contracts;

namespace Mc2.CrudTest.Application.UseCases.Customer.Queries;

public class GetCustomerById : IQuery<GetCustomerByIdReq, CustomerResponse>
{
    public async Task<CustomerResponse> Execute(GetCustomerByIdReq? request)
    {
        throw new NotImplementedException();
    }
}