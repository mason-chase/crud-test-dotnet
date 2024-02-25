using LinqKit;
using Mc2.CrudTest.Presentation.Server.DataAccess;
using Mc2.CrudTest.Presentation.Server.DataAccess.Dao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Mc2.CrudTest.Presentation.Server.Core.Repository
{
    public class BaseAsyncRepository<TEntity> : IBaseAsyncRepository<TEntity> where TEntity : class, IEntity, ISoftDelete
    {
        public DbContext dbContext { get; set; }

        public DbSet<TEntity> Entities { get; }
        public virtual IQueryable<TEntity> Table => Entities.Where(p => p.Status != Status.Deleted);
        public virtual IQueryable<TEntity> TableNoTracking => Entities.Where(p => p.Status != Status.Deleted).AsNoTrackingWithIdentityResolution();
        public virtual IQueryable<TEntity> TableNoTrackingWithDeleted => Entities.AsNoTrackingWithIdentityResolution();

        public BaseAsyncRepository(DbContext dbContextt)
        {
            dbContext = dbContextt;
            Entities = dbContext.Set<TEntity>();
        }

		public virtual async Task<List<TEntity>> ListAllAsync(CancellationToken cancellationToken)
        {
            return await Entities.ToListAsync(cancellationToken);
        }
        public virtual async Task<List<TEntity>> ListAllAsync(Expression<Func<TEntity, bool>> searchExpression, CancellationToken cancellationToken)
        {
            return await Entities.Where(searchExpression).ToListAsync(cancellationToken);
        }
        public virtual async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            await Entities.AddAsync(entity, cancellationToken);
            dbContext.SaveChanges();
        }

        public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
        {
            await Entities.AddRangeAsync(entities, cancellationToken);
        }

        public virtual async Task UpdateAsync(Expression<Func<TEntity, bool>> updateExpression,
            Expression<Func<SetPropertyCalls<TEntity>, SetPropertyCalls<TEntity>>> setPropertyCallExpression, CancellationToken cancellationToken)
        {
            await Entities.Where(updateExpression).ExecuteUpdateAsync(setPropertyCallExpression, cancellationToken);
            dbContext.SaveChanges();
        }

        public virtual async Task DeleteAsync(Expression<Func<TEntity, bool>> deleteExpression, CancellationToken cancellationToken)
        {
            await Entities.Where(deleteExpression)
                .Select(x => x as ISoftDelete)
                .ExecuteUpdateAsync(setter => setter.SetProperty(p => p.Status, Status.Deleted), cancellationToken);

            dbContext.SaveChanges();
        }


    }
}
