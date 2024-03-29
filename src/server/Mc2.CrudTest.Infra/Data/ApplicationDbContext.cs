using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Infra.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Infra.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new CustomerConfig());
    }
}