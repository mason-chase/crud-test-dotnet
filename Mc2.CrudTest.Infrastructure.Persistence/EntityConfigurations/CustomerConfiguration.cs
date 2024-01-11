using Mc2.CrudTest.Domain.Customers.Entities.Write;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mc2.CrudTest.Infrastructure.Persistence.EntityConfigurations;

internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .IsRequired()
            .ValueGeneratedNever();

        builder.Property(c => c.Firstname)
            .IsRequired()
            .HasMaxLength(128);

        builder.Property(c => c.Lastname)
            .IsRequired()
            .HasMaxLength(128);

        builder.Property(c => c.DateOfBirth)
            .IsRequired()
            .HasColumnType("DATE");

        builder.Property(c => c.PhoneNumber)
            .IsRequired()
            .HasMaxLength(32);

        builder.Property(c => c.Email)
            .IsRequired()
            .HasMaxLength(128);

        builder.Property(c => c.BankAccountNumber)
            .IsRequired();

        builder.HasIndex(c => new { c.Firstname, c.Lastname, c.DateOfBirth })
            .IsUnique();

        builder.HasIndex(c => c.Email)
            .IsUnique();

        builder.Ignore(c => c.DomainEvents);
    }
}
