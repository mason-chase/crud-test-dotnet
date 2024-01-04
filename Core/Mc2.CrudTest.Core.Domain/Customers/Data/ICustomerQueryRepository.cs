
using Mc2.CrudTest.Core.Domain.Customers.Dtoes;
using Mc2.CrudTest.Core.Domain.Customers.Queries;

namespace Mc2.CrudTest.Core.Domain.Customers.Data
{
    public interface ICustomerQueryRepository
    {
        List<CustomerSummary> Query(GetAllCustomersQuery query);
        CustomerSummary Query(GetCustomerByIdQuery query);
    }
}
