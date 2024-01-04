

namespace Mc2.CrudTest.Core.Domain.Customers.Data
{
    public interface ICustomerRepository
    {
        bool Exists(Guid id);

        Entities.Customer Load(Guid id);

        void Save(Entities.Customer entity);
    }
}
