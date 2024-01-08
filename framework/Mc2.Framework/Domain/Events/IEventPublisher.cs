namespace Mc2.Framework.Domain.Events;

public interface IEventPublisher
{
    void Publish<TEvent>(TEvent @event) where TEvent : IEvent;
}