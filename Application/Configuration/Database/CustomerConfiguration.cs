using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Application.Configuration.Database
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.DateOfBirth)
                .IsRequired()
                .HasColumnType("Date");

            builder.Property(c => c.PhoneNumber)
                .HasMaxLength(20);

            builder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(c => new { c.FirstName, c.LastName, c.DateOfBirth }).IsUnique();
            builder.HasIndex(c => c.Email).IsUnique();

            builder.Property(c => c.BankAccountNumber)
                .HasMaxLength(20);
        }
    }
}
