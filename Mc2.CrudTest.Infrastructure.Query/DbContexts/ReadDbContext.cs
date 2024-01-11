using Mc2.CrudTest.Domain.Customers.Entities.Read;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Infrastructure.Query.DbContexts;

internal class ReadDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }

    public ReadDbContext(DbContextOptions<ReadDbContext> dbOptions) : base(dbOptions)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Customer>()
            .ToView("CustomersView")
            .HasIndex(c => c.Id);
    }
}
