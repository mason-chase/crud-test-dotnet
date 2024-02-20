using CrudTest.Models.Entities.Marketing.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CrudTest.Data.Context.Configurations
{
    public class CustomerConfigurations : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasIndex(x => x.FirstName)
            .IsUnique();

            builder.HasIndex(x => x.LastName)
            .IsUnique();

            builder.HasIndex(x => x.PhoneNumber)
            .IsUnique();

            builder.HasIndex(x => x.DateOfBirth)
                .IsUnique();
        }
    }
}
