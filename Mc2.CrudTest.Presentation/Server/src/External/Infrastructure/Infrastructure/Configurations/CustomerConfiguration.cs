using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class CustomerConfiguration
{
    public CustomerConfiguration(EntityTypeBuilder<Customer> builder)
    {
        builder.HasIndex(x => x.Id);
        builder.HasIndex(c => new { c.Firstname, c.Lastname, c.DateOfBirth }).IsUnique();
        builder.HasIndex(c => c.Email).IsUnique();
        builder.Property(x => x.Firstname).HasMaxLength(255).IsRequired();
        builder.Property(x => x.Lastname).HasMaxLength(255).IsRequired();
    }
}