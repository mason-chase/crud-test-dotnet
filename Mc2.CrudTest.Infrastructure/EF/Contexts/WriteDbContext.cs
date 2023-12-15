using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Infrastructure.EF.Config;
using Microsoft.EntityFrameworkCore;
namespace Mc2.CrudTest.Infrastructure.EF.Contexts
{
    internal sealed class WriteDbContext:DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Shamsaii");

            var configuration = new WriteConfiguration();
            modelBuilder.ApplyConfiguration<Customer>(configuration);
        }
    }
}
