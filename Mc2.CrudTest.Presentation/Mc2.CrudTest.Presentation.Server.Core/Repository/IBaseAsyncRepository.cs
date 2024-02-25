using Mc2.CrudTest.Presentation.Server.DataAccess.Dao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;


namespace Mc2.CrudTest.Presentation.Server.Core.Repository
{
    public interface IBaseAsyncRepository<TEntity> where TEntity : class, IEntity
    {
        DbSet<TEntity> Entities { get; }
        IQueryable<TEntity> Table { get; }
        IQueryable<TEntity> TableNoTracking { get; }

        Task<List<TEntity>> ListAllAsync(CancellationToken cancellationToken);
        Task AddAsync(TEntity entity, CancellationToken cancellationToken);
        Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken);
        Task UpdateAsync(Expression<Func<TEntity, bool>> updateExpression,
            Expression<Func<SetPropertyCalls<TEntity>, SetPropertyCalls<TEntity>>> setPropertyCallExpression, CancellationToken cancellationToken);
        Task DeleteAsync(Expression<Func<TEntity, bool>> deleteExpression, CancellationToken cancellationToken);

    }
}
