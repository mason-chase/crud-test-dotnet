using Mc2.CrudTest.Application.DTO;
using Mc2.CrudTest.Infrastructure.EF.Contexts;
using Mc2.CrudTest.Infrastructure.EF.Models;
using Mc2.CrudTest.Infrastructure.EF.Queries;
using Mc2.CrudTest.Shared.Abstraction.Queries;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Application.Queires.Handler
{
    internal sealed class GetCustomerByIdHandler : IQueryHandler<GetCustomerById, CustomerDto>
    {
        private readonly DbSet<CustomerReadModel> _customers;
        public GetCustomerByIdHandler(ReadDbContext readDbContext)
        {
            _customers=readDbContext.Customers;
        }
        public async Task<CustomerDto> Handle(GetCustomerById query)
        {
            return await _customers
                .Where(c => c.Id == query.Id)
                .Select(c=>c.ToDto())
                .AsNoTracking()
                .SingleOrDefaultAsync();
        }
    }
}
