using Mc2.CrudTest.Contracts;

namespace Mc2.CrudTest.Application.UseCases.Customer.Comands;

public class RemoveCustomer : ICommand<RemoveCustomerReq, CustomerResponse>
{
    public async Task<CustomerResponse> Execute(RemoveCustomerReq request)
    {
        throw new NotImplementedException();
    }
}