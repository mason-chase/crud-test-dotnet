using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts
{
    public class CrudDbContext :DbContext
    {
        public CrudDbContext(DbContextOptions<CrudDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
