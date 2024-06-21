using Mc2.CrudTest.Modules.Customers.Domain.CustomerAggregate;
using Mc2.CrudTest.Modules.Customers.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mc2.CrudTest.Shared.DataStore.Entities;

public class Configuration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");

        builder.HasKey(x => x.Id);

        builder.HasIndex(x => x.CreatedAt);
        builder.Property(x => x.CreatedAt).HasDefaultValueSql("getdate()");

        builder.HasIndex(x => new { x.FirstName, x.LastName, x.DateOfBirth }).IsUnique();
        builder.HasIndex(x => x.Email).IsUnique();

        builder.Property(x => x.PhoneNumber);
        builder.HasIndex(x => x.PhoneNumber);
    }
}