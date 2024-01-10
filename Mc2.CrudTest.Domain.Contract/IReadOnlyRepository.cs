using Mc2.CrudTest.Core;

namespace Mc2.CrudTest.Domain.Contract;

public interface IReadOnlyRepository<TEntity, in TKey> : IDisposable
    where TEntity : IEntity<TKey>
    where TKey : IEquatable<TKey>
{
    Task<TEntity?> GetByIdAsync(TKey id);
}
