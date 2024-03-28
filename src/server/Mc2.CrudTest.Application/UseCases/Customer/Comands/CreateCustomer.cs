using Mc2.CrudTest.Contracts;

namespace Mc2.CrudTest.Application.UseCases.Customer.Comands;

public class CreateCustomer : ICommand<CreateCustomerReq, CustomerResponse>
{
    public async Task<CustomerResponse> Execute(CreateCustomerReq request)
    {
        // Implement Logic To Insert New Customer To The DataBase
        throw new NotImplementedException();
    }
}