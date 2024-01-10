namespace Mc2.CrudTest.Domain.Contract;

public interface IEventStoreRepository : IDisposable
{
    Task StoreAsync(IEnumerable<EventStore> eventStores);
}
