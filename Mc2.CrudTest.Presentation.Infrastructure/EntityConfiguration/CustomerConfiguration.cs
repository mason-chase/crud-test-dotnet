using Mc2.CrudTest.Presentation.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Mc2.CrudTest.Presentation.Infrastructure.EntityConfiguration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer", "Sale");

            builder.HasKey(o => o.Id);

            builder.HasIndex(u => u.Email).IsUnique();

            builder.HasIndex(u => new { u.FirstName , u.LastName , u.DateOfBirth }, "UniqueNameAndBirthDate").IsUnique();


            builder.Property(e => e.PhoneNumber).HasMaxLength(15).HasColumnType("varchar");

            builder.Property(e => e.FirstName).HasMaxLength(100);
            builder.Property(e => e.LastName).HasMaxLength(100);
            builder.Property(e => e.Email).HasMaxLength(256);
            builder.Property(e => e.BankAccountNumber).HasMaxLength(30);


        }
    }
}
