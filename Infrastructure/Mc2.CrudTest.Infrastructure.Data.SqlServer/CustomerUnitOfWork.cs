using Mc2.CrudTest.Framework.Domain.Data;
using Mc2.CrudTest.Framework.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Mc2.CrudTest.Infrastructure.Data.SqlServer
{
    public class CustomerUnitOfWork : IUnitOfWork
    {
        private readonly CustomerDbContext _customerDbContext;
        private readonly IEventSource _eventSource;

        public CustomerUnitOfWork(CustomerDbContext customerDbContext, IEventSource eventSource)
        {
            _customerDbContext = customerDbContext;
            _eventSource = eventSource;
        }
        public int Commit()
        {
            var entityForSave = GetEnityForSave();
            var result = _customerDbContext.SaveChanges();
            SaveEvents(entityForSave);
            return result;
        }

        private void SaveEvents(List<EntityEntry> entityForSave)
        {
            foreach (var item in entityForSave)
            {
                var root = item.Entity as BaseAggregateRoot<Guid>;
                if (root != null)
                {
                    var id = root.Id.ToString();
                    var aggName = item.Entity.GetType().FullName;
                    _eventSource.Save(aggName, id, root.GetEvents());
                }

            }
        }

        private List<EntityEntry> GetEnityForSave()
        {
            return _customerDbContext.ChangeTracker
                                     .Entries()
                                     .Where(x => x.State == EntityState.Modified ||
                                            x.State == EntityState.Added || 
                                            x.State == EntityState.Deleted)
                                     .ToList();
        }
    }
}