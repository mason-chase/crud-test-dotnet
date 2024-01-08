using Mc2.Framework.Domain.Events;

namespace Mc2.Framework.TestDoubles;


public class FakeEventPublisher : IEventPublisher
{
    private readonly List<object> _publishedEvents = [];

    public void ClearHistory() => _publishedEvents.Clear();

    public List<object> GetPublishedEvents() => _publishedEvents;

    public TEvent GetEventByIndex<TEvent>(int index) where TEvent : class, IEvent
    {
        return _publishedEvents[index] as TEvent;
    }

    public TEvent GetLastEvent<TEvent>() where TEvent : class, IEvent
    {
        return _publishedEvents[_publishedEvents.Count - 1] as TEvent;
    }

    public void Publish<TEvent>(TEvent @event) where TEvent : IEvent
    {
        _publishedEvents.Add(@event);
    }
}