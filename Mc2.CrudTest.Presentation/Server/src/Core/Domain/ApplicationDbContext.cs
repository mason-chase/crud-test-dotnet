using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Domain.Configuration;
using Domain.Entities;

namespace Domain;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        new CustomerConfiguration(modelBuilder.Entity<Customer>());
    }

    public virtual DbSet<Customer> Customers { get; set; }
}