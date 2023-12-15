using Mc2.CrudTest.Application.DTO;
using Mc2.CrudTest.Shared.Abstraction.Queries;

namespace Mc2.CrudTest.Application.Queires.Handler
{
    internal sealed class GetCustomerByNameHandler : IQueryHandler<GetCustomerByName, CustomerDto>
    {
        
        public GetCustomerByNameHandler()
        {
            
        }
        public async Task<CustomerDto> Handle(GetCustomerByName query)
        {
            return null;
        }
    }
}
