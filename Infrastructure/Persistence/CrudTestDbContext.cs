using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Application.Common.Interfaces.Tools;
using Infrastructure.Persistence.Interceptors;


namespace Infrastructure.Persistence;

public class CrudTestDbContext : DbContext, ICrudTestDbContext
{
    private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;

    public CrudTestDbContext(DbContextOptions<CrudTestDbContext> options, 
   AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor)
        : base(options)
    {
        Database.EnsureCreated();
        _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
    }
    //***********************************************************************************************

    #region Customers
    public DbSet<Customer> Customers { get; set; }
    #endregion

    //***********************************************************************************************


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }
}
