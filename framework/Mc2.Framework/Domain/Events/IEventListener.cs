namespace Mc2.Framework.Domain.Events;

public interface IEventListener
{
    void Subscribe<TEvent>(IEventHandler<TEvent> eventHandler) where TEvent : IEvent;
}