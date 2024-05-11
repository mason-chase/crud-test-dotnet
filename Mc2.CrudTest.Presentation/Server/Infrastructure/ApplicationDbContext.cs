using Mc2.CrudTest.Presentation.Shared.Events;
using Mc2.CrudTest.Presentation.Shared.ReadModels;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Presentation.Infrastructure;

public class ApplicationDbContext: DbContext
{
    public DbSet<EventBase> Events { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EventBase>().HasKey(e => e.EventId);
      // Additional configuration as needed
    }
}