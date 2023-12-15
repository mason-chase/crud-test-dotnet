using Mc2.CrudTest.Infrastructure.EF.Config;
using Mc2.CrudTest.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Infrastructure.EF.Contexts
{
    internal sealed class ReadDbContext: DbContext
    {
        public DbSet<CustomerReadModel> Customers { get; set; }
        public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Shamsaii");

            var configuration = new ReadConfiguration();
            modelBuilder.ApplyConfiguration<CustomerReadModel>(configuration);
        }
    }
}
