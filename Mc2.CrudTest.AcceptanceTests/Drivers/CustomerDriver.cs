using Mc2.CrudTest.Presentation.Contracts.Customers;
using System;

namespace Mc2.CrudTest.AcceptanceTests.Drivers
{
    public class CustomerDriver(ICustomerAppService customerAppService):ICustomerDriver
    {
        private readonly ICustomerAppService _customerAppService = customerAppService;

        public async Task CreateCustomer(CustomerCommand customer)
        {
           await _customerAppService.CreateCustomer(customer);
        }

        public async Task DeleteCustomer(int id)
        {
           await  _customerAppService.DeleteCustomer(id);
        }

        public async Task<List<CustomerQuery>> GetCustomers()
        {
            return await _customerAppService.GetCustomers();
        }

        public async Task UpdateCustomer(int id,CustomerCommand customer)
        {
            await _customerAppService.UpdateCustomer(id,customer);
        }
    }
    
}