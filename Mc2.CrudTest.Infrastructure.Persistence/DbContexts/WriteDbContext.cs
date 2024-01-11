using Mc2.CrudTest.Domain.Customers.Entities.Write;
using Mc2.CrudTest.Infrastructure.Persistence.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Infrastructure.Persistence.DbContexts;

internal class WriteDbContext : BaseDbContext<WriteDbContext>
{
    public DbSet<Customer> Customers { get; set; }

    public WriteDbContext(DbContextOptions<WriteDbContext> dbOptions) : base(dbOptions)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
    }
}
