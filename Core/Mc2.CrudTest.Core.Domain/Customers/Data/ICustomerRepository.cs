

using Mc2.CrudTest.Core.Domain.Customers.Entities;

namespace Mc2.CrudTest.Core.Domain.Customers.Data
{
    public interface ICustomerRepository
    {
        bool Exists(Guid id);

        Customer Load(Guid id);

        void Add(Customer entity);
    }
}
