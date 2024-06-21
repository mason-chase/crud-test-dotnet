using Mc2.CrudTest.Modules.Customers.Domain.CustomerAggregate;
using Mc2.CrudTest.Modules.Customers.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Shared.DataStore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}