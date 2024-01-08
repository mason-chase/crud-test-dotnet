using Mc2.CrudTest.Core.Domain.Customers.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Diagnostics.CodeAnalysis;

namespace Mc2.CrudTest.Infrastructure.Data.SqlServer
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

        }

        public DbSet<Customer> Customers { get; set; }
    }

    public class CustomerDbContextFactory : IDesignTimeDbContextFactory<CustomerDbContext>
    {
        public CustomerDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CustomerDbContext>();
            optionsBuilder.UseSqlServer("Server = .; Database=CustomerDb;Integrated Security=true;TrustServerCertificate=True;");

            return new CustomerDbContext(optionsBuilder.Options);
        }
    }
}
