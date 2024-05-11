using Mc2.CrudTest.Presentation.Infrastructure;
using Mc2.CrudTest.Presentation.Shared.Entities;
using Mc2.CrudTest.Presentation.Shared.Events;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Mc2.CrudTest.Presentation.DomainServices;

public class EventStoreService
{
    private readonly ApplicationDbContext _context;

    public EventStoreService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Customer> RehydratePersonAsync(Guid personId)
    {
        var events = await _context.Events
            .Where(e => e.AggregateId == personId)
            .OrderBy(e => e.CreatedAt)
            .ToListAsync();

        var customer = new Customer(); 

        foreach (EventBase event in events)
        {
            var eventData = JsonConvert.DeserializeObject(event.eventData);
            customer.Apply(eventData);
        }

        return customer;
    }
    
}