using Mc2.CrudTest.Presentation.Shared.Events;
using Newtonsoft.Json;

namespace Mc2.CrudTest.Presentation.Infrastructure;

public class EventStoreRepository
{
    private readonly ApplicationDbContext _context;

    public EventStoreRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task SaveEventAsync<T>(T @event) where T : EventBase
    {
        var eventData = new EventData
        {
            EventId = Guid.NewGuid(),
            AggregateId = @event.AggregateId,
            AggregateType = typeof(T).Name,
            EventType = @event.GetType().Name,
            Data = JsonConvert.SerializeObject(@event),
            CreatedAt = DateTime.UtcNow
        };

        _context.Events.Add(eventData);
        await _context.SaveChangesAsync();
    }
}

public class EventData
{
    public Guid EventId { get; set; }
    public object AggregateId { get; set; }
    public string AggregateType { get; set; }
    public string EventType { get; set; }
    public object Data { get; set; }
    public DateTime CreatedAt { get; set; }
}