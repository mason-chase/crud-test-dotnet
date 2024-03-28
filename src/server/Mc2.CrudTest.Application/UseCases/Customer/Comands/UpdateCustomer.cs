using Mc2.CrudTest.Contracts;

namespace Mc2.CrudTest.Application.UseCases.Customer.Comands;

public class UpdateCustomer : ICommand<UpdateCustomerReq, CustomerResponse>
{
    public async Task<CustomerResponse> Execute(UpdateCustomerReq request)
    {
        // TODO: Implements Logic to Update Given Customer
        throw new NotImplementedException();
    }
}