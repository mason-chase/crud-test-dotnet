using Mc2.CrudTest.Core.Domain.Customers.Entities;
using Mc2.CrudTest.Core.Domain.Customers.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mc2.CrudTest.Infrastructure.Data.SqlServer.Customers
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(c => c.PhoneNumber).HasMaxLength(12).IsUnicode(false).HasConversion(c => c.Value.ToString(), d => PhoneNumber.FromString(d));
            builder.Property(c => c.BankAccountNumber).HasMaxLength(10).IsUnicode(false).HasConversion(c => c.Value.ToString(), d => BankAccountNumber.FromString(d));
            builder.Property(c => c.Email).HasMaxLength(50).IsUnicode(false).HasConversion(c => c.Value.ToString(), d => Email.FromString(d));
            builder.Property(c => c.FirstName).HasMaxLength(50);
            builder.Property(c => c.LastName).HasMaxLength(50);
        }
    }
}
