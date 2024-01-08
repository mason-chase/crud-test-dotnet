

using Mc2.CrudTest.Core.Domain.Customers.Data;
using Mc2.CrudTest.Core.Domain.Customers.Entities;

namespace Mc2.CrudTest.AcceptanceTests.Infra
{
    internal class InMemoryCustomerRepository : ICustomerRepository
    {
        private List<Customer> _customers = new List<Customer>();
        public void Add(Customer entity)
        {
            _customers.Add(entity);
        }

        public bool Exists(Guid id)
        {
           return _customers.Exists(x => x.Id == id);
        }

        public Customer FindByEmail(string email)
        {
            return _customers.FirstOrDefault(x => x.Email == email);
        }

        public Customer Load(Guid id)
        {
            return _customers.FirstOrDefault(x => x.Id == id);
        }
    }
}
