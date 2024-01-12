using ClassLibrary1Mc2.CrudTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mc2.CrudTest.Infrastructure.Data.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");

        builder.Property(c => c.PhoneNumber)
            .HasColumnType("nvarchar(15)");
        builder.Property(c => c.Email)
            .HasColumnType("nvarchar(50)");
        builder.Property(c => c.FirstName)
            .HasColumnType("nvarchar(50)");
        builder.Property(c => c.LastName)
            .HasColumnType("nvarchar(50)");
        builder.Property(c => c.BankAccountNumber)
                    .HasColumnType("nvarchar(30)");
        
        builder
            .HasIndex(c => new { c.FirstName, c.LastName, c.DateOfBirth, c.IsRemoved })
            .IsUnique();

        builder.HasIndex(x => x.Email).IsUnique();
        builder.Property(x => x.Email).IsRequired();

        builder.Property(x => x.PhoneNumber).IsRequired();
        builder.Property(x => x.FirstName).IsRequired();
        builder.Property(x => x.LastName).IsRequired();
        builder.Property(x => x.BankAccountNumber).IsRequired();
        builder.Property(x => x.DateOfBirth).IsRequired();
    }
}