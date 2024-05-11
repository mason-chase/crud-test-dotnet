using Mc2.CrudTest.Presentation.Infrastructure;
using Mc2.CrudTest.Presentation.Shared.ReadModels;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Presentation.DomainServices;

public class CustomerEventReadService
{
    private readonly ReadModelDbContext _context;

    public CustomerEventReadService(ReadModelDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CustomerReadModel>> GetEventsForCustomerAsync(Guid customerId)
    {
        return await _context.PersonEvents
            .Where(e => e.AggregateId == customerId)
            .OrderBy(e => e.OccurredOn)
            .ToListAsync();
    }
}