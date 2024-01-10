using Mc2.CrudTest.Core;
using Mc2.CrudTest.Domain.Contract;
using Mc2.CrudTest.Infrastructure.Query.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Infrastructure.Query.Repositories;

internal class BaseReadOnlyRepository<TEntity, TKey> : IReadOnlyRepository<TEntity, TKey>
    where TEntity : class, IEntity<TKey>
    where TKey : IEquatable<TKey>
{
    private bool _disposed;
    private readonly DbSet<TEntity> _dbSet;
    protected readonly ReadDbContext _readDbContext;

    public BaseReadOnlyRepository(ReadDbContext readDbContext)
    {
        _readDbContext = readDbContext;
        _dbSet = _readDbContext.Set<TEntity>();
    }

    public async Task<TEntity?> GetByIdAsync(TKey id)
    {
        return await _dbSet.FirstOrDefaultAsync(c => c.Id.Equals(id));
    }

    ~BaseReadOnlyRepository() => Dispose(false);

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
            _readDbContext.Dispose();
        }

        _disposed = true;
    }
}
