using Mc2.CrudTest.Presentation.Shared.Events;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Mc2.CrudTest.Presentation.Infrastructure;

public class EventStoreRepository: IEventRepository
{
    private readonly ApplicationDbContext _context;

    public EventStoreRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task SaveEventAsync(EventBase @event) 
    {
        _context.Events.Add(@event);
        await _context.SaveChangesAsync();
    }
}



