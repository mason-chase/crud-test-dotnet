using System.Linq.Expressions;
using Mc2.CrudTest.Shared.BuildingBlocks.AggregateRoot;

namespace Mc2.CrudTest.Shared.BuildingBlocks.Stores;

public interface IRepository<TAgg, TId> where TAgg : AggregateRoot<TId>
{
    void Add(TAgg entity);
    void Update(TAgg entity);
    void Remove(TAgg entity);
    Task<TAgg?> SingleOrDefaultAsync(Expression<Func<TAgg, bool>> predicate, CancellationToken cancellationToken = default);
    Task<TAgg?> FirstOrDefaultAsync(Expression<Func<TAgg, bool>> predicate, CancellationToken cancellationToken = default);
    Task<bool> AnyAsync(Expression<Func<TAgg, bool>> predicate, CancellationToken cancellationToken = default);
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}