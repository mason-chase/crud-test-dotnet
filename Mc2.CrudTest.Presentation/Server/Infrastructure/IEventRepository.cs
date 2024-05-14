using Mc2.CrudTest.Presentation.Shared.Events;
using Mc2.CrudTest.Presentation.Shared.ReadModels;

namespace Mc2.CrudTest.Presentation.Infrastructure;

public interface IEventRepository
{
    public Task SaveEventAsync(EventBase @event);
    public Task<List<CustomerReadModel>> GetEventsAsync(Guid aggregateId);
}