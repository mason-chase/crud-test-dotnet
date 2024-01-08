namespace Mc2.Framework.Domain.Events;

public class EventAggregator: IEventListener, IEventPublisher
{
    private List<object> _subscribers = [];
    public void Subscribe<TEvent>(IEventHandler<TEvent> eventHandler) where TEvent : IEvent
    {
       _subscribers.Add(eventHandler);
    }

    public void Publish<TEvent>(TEvent @event) where TEvent : IEvent
    {
        _subscribers.OfType<IEventHandler<TEvent>>().ToList()
            .ForEach(handler => handler.Handle(@event));
    }
}