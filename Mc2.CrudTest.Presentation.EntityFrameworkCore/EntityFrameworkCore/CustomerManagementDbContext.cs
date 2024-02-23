using Mc2.CrudTest.Presentation.Domain.Customers;
using Mc2.CrudTest.Presentation.EntityFrameworkCore.EntityFrameworkCore.Customers;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Presentation.EntityFrameworkCore.EntityFrameworkCore;

public class CustomerManagementDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Customer> Customers { get; private set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().HasQueryFilter(x => !x.IsDeleted);
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}
