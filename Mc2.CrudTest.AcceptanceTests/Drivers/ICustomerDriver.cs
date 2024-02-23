using Mc2.CrudTest.Presentation.Contracts.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.AcceptanceTests.Drivers
{
    public interface ICustomerDriver
    {
        Task CreateCustomer(CustomerCommand customer);
        Task UpdateCustomer(int id,CustomerCommand customer);
        Task<List<CustomerQuery>> GetCustomers();
        Task DeleteCustomer(int id);
    }
}
