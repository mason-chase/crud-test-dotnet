using Mc2.CrudTest.Application.DTO;
using Mc2.CrudTest.Domain.ValueObjects;
using Mc2.CrudTest.Shared.Abstraction.Queries;

namespace Mc2.CrudTest.Application.Queires
{
    public class GetCustomerByName: IQuery<CustomerDto>
    {
        public CustomerFullName FullName { get; set; }
        public DateOnly Birthday { get; set; }
    }
}
