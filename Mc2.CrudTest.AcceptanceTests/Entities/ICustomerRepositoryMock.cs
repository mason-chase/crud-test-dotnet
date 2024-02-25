using EntityFrameworkCoreMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.AcceptanceTests.Entities
{
    public class ICustomerRepositoryMock
    {
        public static CustomerRepository GetMock()
        {
            List<Customer> lstUser = GenerateTestData();
            DataContext dbContextMock = DbContextMock.GetMock<Customer, DataContext>(lstUser, x => x.M_Customer);
            return new CustomerRepository(dbContextMock);
        }

        private static List<Customer> GenerateTestData()
        {
            List<Customer> lstUser = new();
            Random rand = new Random();
            for (int index = 1; index <= 10; index++)
            {
                lstUser.Add(new Customer
                {
                    Id = index,
                    FirstName = "Customer-" + index,
                    LastName = "CustomerLast-" + index

                });
            }
            return lstUser;
        }
    }
}
