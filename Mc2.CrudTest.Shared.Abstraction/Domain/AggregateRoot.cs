namespace Mc2.CrudTest.Shared.Abstraction.Domain
{
    public abstract class AggregateRoot<T>
    {
        public T Id { get; protected set; }
        public int Version { get; protected set; }
        private bool _versionIncremented { get; set; }

        public IEnumerable<IDomainEvent> Events => _events;
        private readonly List<IDomainEvent> _events = new();
        protected void AddEvent(IDomainEvent @event)
        {
            if (!_events.Any() && !_versionIncremented)
            {
                _versionIncremented = true;
                Version++;
            }
            _events.Add(@event);
        }
        public void ClearEvents() => _events.Clear();
        protected void IncrementVersion()
        {
            if (_versionIncremented)
            {
                return;
            }
            Version++;
            _versionIncremented = true;
        }
    }
}
