using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Persistence.EntityConfigurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.Property(t => t.FirstName)
            .IsRequired()
            .HasColumnType("varchar(50)");

        builder.Property(t => t.LastName)
           .IsRequired()
           .HasColumnType("varchar(50)");

        builder.Property(t => t.DateOfBirth)
            .IsRequired()
             .HasColumnType("date");

        builder.Property(t => t.PhoneNumber)
            .IsRequired()
            .HasPrecision(12, 0);

        builder.Property(t => t.Email)
            .IsRequired()
            .HasMaxLength(100)
        .HasColumnType("varchar(100)");

        builder.Property(t => t.BankAccountNumber)
            .IsRequired()
            .HasColumnType("varchar(18)");

        builder.HasIndex(t => new { t.FirstName, t.LastName, t.DateOfBirth })
              .IsUnique();

        builder.HasIndex(t => t.Email).IsUnique();
    }
}
