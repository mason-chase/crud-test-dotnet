using Mc2.CrudTest.Domain;
using Mc2.CrudTest.Infrastructure.Persistence.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Infrastructure.Persistence.DbContexts;

internal class EventStoreDbContext : BaseDbContext<EventStoreDbContext>
{
    public DbSet<EventStore> EventStores => Set<EventStore>();

    public EventStoreDbContext(DbContextOptions<EventStoreDbContext> dbOptions) : base(dbOptions)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new EventStoreConfiguration());
    }
}
