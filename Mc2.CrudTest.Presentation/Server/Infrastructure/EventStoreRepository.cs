using Mc2.CrudTest.Presentation.Shared.Events;
using Mc2.CrudTest.Presentation.Shared.ReadModels;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Mc2.CrudTest.Presentation.Infrastructure;

public class EventStoreRepository: IEventRepository
{
    private readonly ApplicationDbContext _context;
    private readonly ReadModelDbContext _readContext;
    public EventStoreRepository(ApplicationDbContext context, ReadModelDbContext readModelDbContext)
    {
        _context = context;
        _readContext = readModelDbContext;
    }

    public async Task SaveEventAsync(EventBase @event) 
    {
        _context.Events.Add(@event);
        await _context.SaveChangesAsync();
    }
    
    public async Task<List<CustomerReadModel>> GetEventsAsync(Guid aggregateId)
    {
        // Retrieve events for the specified aggregate ID
        return await _readContext.CustomerEvents
            .Where(e => e.AggregateId == aggregateId)
            .OrderBy(e => e.OccurredOn)
            .ToListAsync();
    }
}



