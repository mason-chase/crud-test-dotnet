using ClassLibrary1Mc2.CrudTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Mc2.CrudTest.Infrastructure.Data;

public class EfDbContext: DbContext
{
    public EfDbContext(DbContextOptions<EfDbContext> options) : base(options)
    {
    } 

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e is { Entity: Customer, State: EntityState.Added });
        foreach (var entry in entries)
        {
            ((Customer)entry.Entity).IsRemoved = false;
        }
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("SqlConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("CrudTest");
        modelBuilder.ApplyConfiguration(new Configurations.CustomerConfiguration());
        base.OnModelCreating(modelBuilder);
        
    }

    public virtual DbSet<Customer> Customers { get; set; }
   
}