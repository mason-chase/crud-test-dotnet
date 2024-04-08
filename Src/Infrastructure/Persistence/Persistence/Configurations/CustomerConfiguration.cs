using Domain.Entities.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(c => c.FirstName).HasMaxLength(50);
            builder.Property(c => c.LastName).HasMaxLength(50);
            builder.Property(c => c.DateOfBirth).HasColumnType("date");
            //builder.Property(c => c.PhoneNumber).IsRequired();
            builder.Property(c => c.Email).HasMaxLength(100);
            builder.Property(c => c.BankAccountNumber).HasMaxLength(20);
        }
    }
}