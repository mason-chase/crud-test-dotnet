

using Mc2.CrudTest.Core.Domain.Customers.Data;
using Mc2.CrudTest.Core.Domain.Customers.Entities;
namespace Mc2.CrudTest.Infrastructure.Data.SqlServer.Customers
{

    public class EfCustomerRespository : ICustomerRepository, IDisposable
    {
        private readonly CustomerDbContext _customerDbContext;

        public EfCustomerRespository(CustomerDbContext customerDbContext)
        {
            _customerDbContext = customerDbContext;
        }
        public void Add(Customer entity)
        {
            _customerDbContext.Customers.Add(entity);
        }

        public bool Exists(Guid id)
        {
            return _customerDbContext.Customers.Any(c => c.Id == id);
        }

        public Customer Load(Guid id)
        {
            return _customerDbContext.Customers.Find(id);
        }

        public void Dispose()
        {
            _customerDbContext.Dispose();
        }
    }
}
