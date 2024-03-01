using Mc2.CrudTest.Presentation.Infrastructure.EntityConfiguration;
using Mc2.CrudTest.Presentation.Shared.Domain;
using Microsoft.EntityFrameworkCore;


namespace Mc2.CrudTest.Presentation.Infrastructure.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.ApplyConfiguration(new CustomerConfiguration());

        }


        #region Cms DbSet

        public DbSet<Customer> Customer { get; set; }

        #endregion

    }
}
