
using Microsoft.EntityFrameworkCore;

namespace Hamideh.Crud.Test.Infrastracture.Persistence.SqlContext
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> dbContextOptions)
                : base(dbContextOptions)
        {

        }

        public DbSet<Customer> Customers => Set<Customer>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(CustomerDbContextSchema.DefaultSchema);

            modelBuilder.Entity<Customer>().HasIndex(p => new { p.FirstName, p.LastName, p.DateOfBirth }).IsUnique();
            modelBuilder.Entity<Customer>().HasIndex(p => new { p.Email }).IsUnique();

        }
    }
}
