using Mc2.CrudTest.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mc2.CrudTest.Infrastructure.EF.Config
{
    internal sealed class ReadConfiguration: IEntityTypeConfiguration<CustomerReadModel>
    {
        public void Configure(EntityTypeBuilder<CustomerReadModel> builder)
        {
            builder.ToTable("Customer");
            builder.HasKey(pl => pl.Id);

            builder
                .Property(pl => pl.FullName)
                .HasConversion(l => l.ToString(), l => FullNameReadModel.Create(l));
        }
    }
}
