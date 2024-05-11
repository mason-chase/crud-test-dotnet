using Mc2.CrudTest.Presentation.Shared.Events;

namespace Mc2.CrudTest.Presentation.Infrastructure;

public interface IEventRepository
{
    public Task SaveEventAsync(EventBase @event);
}