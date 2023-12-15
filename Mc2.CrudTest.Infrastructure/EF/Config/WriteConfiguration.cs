using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Mc2.CrudTest.Infrastructure.EF.Config
{
    internal sealed class WriteConfiguration: IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(pl => pl.Id);

            var packingFullNameConverter = new ValueConverter<CustomerFullName, string>(l => l.ToString(),
                l => CustomerFullName.Create(l));

            var packingListBirthdayConverter = new ValueConverter<CustomerBirthday, DateOnly>(pln => pln.Value,
                pln => new CustomerBirthday(pln));

            var packingEmailConverter = new ValueConverter<CustomerEmail, string>(pln => pln.Value,
               pln => new CustomerEmail(pln));

            var packingBankAccountNumberConverter = new ValueConverter<CustomerBankAccountNumber, string>(pln => pln.Value,
               pln => new CustomerBankAccountNumber(pln));

            var packingPhoneNumberConverter = new ValueConverter<CustomerPhoneNumber, long>(pln => pln.Value,
              pln => new CustomerPhoneNumber(pln));

            builder
                .Property(pl => pl.Id)
                .HasConversion(id => id.Value, id => new CustomerId(id));

            builder
               .Property(typeof(CustomerFullName), "_fullName")
               .HasConversion(packingFullNameConverter)
               .HasColumnName("FullName");

            builder
               .Property(typeof(CustomerBirthday), "_birthday")
               .HasConversion(packingListBirthdayConverter)
               .HasColumnName("Birthday");

            builder
                .Property(typeof(CustomerEmail), "_email")
                .HasConversion(packingEmailConverter)
                .HasColumnName("Email");

            builder
                .Property(typeof(CustomerBankAccountNumber), "_bankAccountNumber")
                .HasConversion(packingBankAccountNumberConverter)
                .HasColumnName("BankAccountNumber");

            builder
              .Property(typeof(CustomerPhoneNumber), "_phoneNumber")
              .HasConversion(packingPhoneNumberConverter)
              .HasColumnName("PhoneNumber");


            builder.ToTable("Customer");
        }
    }
}
