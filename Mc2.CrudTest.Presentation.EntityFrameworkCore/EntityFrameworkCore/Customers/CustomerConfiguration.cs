using Mc2.CrudTest.Presentation.Domain.Customers;
using Mc2.CrudTest.Presentation.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mc2.CrudTest.Presentation.EntityFrameworkCore.EntityFrameworkCore.Customers
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable(nameof(Customer));

            builder.HasKey(c => c.Id);

            builder.Property(c => c.FirstName).HasMaxLength(CustomerConsts.ShortTextSise);
            builder.Property(c => c.LastName).HasMaxLength(CustomerConsts.ShortTextSise);
            builder.Property(c => c.Email).HasMaxLength(CustomerConsts.ShortTextSise);
            builder.Property(c => c.PhoneNumber).HasMaxLength(CustomerConsts.PhoneNumberrSize);
            builder.Property(c => c.IsDeleted).HasColumnType("BIT");

            builder.HasIndex(c => new { c.FirstName, c.LastName, c.DateOfBirth })
            .IsUnique();

        }
    }
}
