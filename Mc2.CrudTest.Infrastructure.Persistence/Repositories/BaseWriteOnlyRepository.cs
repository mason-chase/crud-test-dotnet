using Mc2.CrudTest.Core;
using Mc2.CrudTest.Domain.Contract;
using Mc2.CrudTest.Infrastructure.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Infrastructure.Persistence.Repositories;
internal class BaseWriteOnlyRepository<TEntity, TKey> : IWriteOnlyRepository<TEntity, TKey>
    where TEntity : class, IEntity<TKey>
    where TKey : IEquatable<TKey>
{
    private bool _disposed;
    private readonly DbSet<TEntity> _dbSet;
    protected readonly WriteDbContext _writeDbContext;

    public BaseWriteOnlyRepository(WriteDbContext writeDbContext)
    {
        _writeDbContext = writeDbContext;
        _dbSet = writeDbContext.Set<TEntity>();
    }

    public void Add(TEntity entity)
    {
        _dbSet.Add(entity);
    }

    public void Update(TEntity entity)
    {
        _dbSet.Update(entity);
    }

    public void Remove(TEntity entity)
    {
        _dbSet.Remove(entity);
    }

    public async Task<TEntity?> GetByIdAsync(TKey id)
    {
        return await _dbSet.AsNoTrackingWithIdentityResolution()
            .FirstOrDefaultAsync(e => e.Id.Equals(id));
    }

    ~BaseWriteOnlyRepository() => Dispose(false);

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
        {
            return;
        }

        if (disposing)
        {
            _writeDbContext.Dispose();
        }

        _disposed = true;
    }
}
