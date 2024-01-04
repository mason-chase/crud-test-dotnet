
using Mc2.CrudTest.Framework.Domain.Events;

namespace Mc2.CrudTest.Framework.Domain.Entities
{


    public abstract class BaseEntity<TId> where TId : IEquatable<TId>
    {
        private readonly List<IEvent> _events;
        private void Raise(IEvent @event) => _events.Add(@event);
        protected void HandleEvent(IEvent @event)
        {
            SetStateByEvent(@event);
            ValidateInvariants();
            Raise(@event);
        }
        protected abstract void SetStateByEvent(IEvent @event);
        public IEnumerable<IEvent> GetChanges() => _events.AsEnumerable();
        public void ClearChanges() => _events.Clear();
        public TId Id { get; protected set; }
        
        protected abstract void ValidateInvariants();

    }
}
