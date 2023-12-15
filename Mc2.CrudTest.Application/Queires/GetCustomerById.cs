using Mc2.CrudTest.Application.DTO;
using Mc2.CrudTest.Shared.Abstraction.Queries;

namespace Mc2.CrudTest.Application.Queires
{
    public class GetCustomerById:IQuery<CustomerDto>
    {
        public Guid Id { get; set; }
    }
}
