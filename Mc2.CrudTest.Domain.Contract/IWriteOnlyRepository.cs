using Mc2.CrudTest.Core;

namespace Mc2.CrudTest.Domain.Contract;

public interface IWriteOnlyRepository<TEntity, in TKey> : IDisposable
    where TEntity : IEntity<TKey>
    where TKey : IEquatable<TKey>
{
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Remove(TEntity entity);
    Task<TEntity?> GetByIdAsync(TKey id);
}
