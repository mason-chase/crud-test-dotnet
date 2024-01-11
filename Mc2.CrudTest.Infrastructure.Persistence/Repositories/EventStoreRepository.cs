using Mc2.CrudTest.Domain;
using Mc2.CrudTest.Domain.Contract;
using Mc2.CrudTest.Infrastructure.Persistence.DbContexts;

namespace Mc2.CrudTest.Infrastructure.Persistence.Repositories;

internal class EventStoreRepository : IEventStoreRepository
{
    private bool _disposed;
    private readonly EventStoreDbContext _dbContext;

    public EventStoreRepository(EventStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task StoreAsync(IEnumerable<EventStore> eventStores)
    {
        await _dbContext.EventStores.AddRangeAsync(eventStores);
        await _dbContext.SaveChangesAsync();
    }

    ~EventStoreRepository() => Dispose(false);

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (_disposed)
        {
            return;
        }

        if (disposing)
        {
            _dbContext.Dispose();
        }

        _disposed = true;
    }
}
