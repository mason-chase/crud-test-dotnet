using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.AcceptanceTests.Entities
{
    public class CustomerRepository 
    {

        private readonly DataContext _dataContext;

        public CustomerRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public bool AddCustomer(Customer Customer)
        {
            if (_dataContext.M_Customer == null)
                return false;

            if (_dataContext.M_Customer.Any(x => x.Id == Customer.Id)) { return false; }

            _dataContext.M_Customer.Add(Customer);
            _dataContext.SaveChanges();
            return true;
        }

        public bool DeleteCustomer(Customer Customer)
        {
            if (_dataContext.M_Customer == null)
                return false;

            if (!_dataContext.M_Customer.Any(x => x.Id == Customer.Id)) { return false; }

            _dataContext.M_Customer.Remove(Customer);
            _dataContext.SaveChanges();
            return true;
        }

        public Customer GetCustomerById(int id)
        {
            if (_dataContext.M_Customer == null)
                return null;

            return _dataContext.M_Customer.FirstOrDefault(x => x.Id == id);
        }

        public IList<Customer> GetCustomers()
        {
            if (_dataContext.M_Customer == null)
                return new List<Customer>();

            return _dataContext.M_Customer.ToList();
        }

        public bool UpdateCustomer(Customer Customer)
        {
            if (_dataContext.M_Customer == null)
                return false;

            if (!_dataContext.M_Customer.Any(x => x.Id == Customer.Id)) { return false; }

            _dataContext.M_Customer.Update(Customer);
            _dataContext.SaveChanges();
            return true;
        }
    }
}
