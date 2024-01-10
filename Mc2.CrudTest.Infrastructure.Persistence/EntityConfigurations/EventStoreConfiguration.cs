using Mc2.CrudTest.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mc2.CrudTest.Infrastructure.Persistence.EntityConfigurations;

internal class EventStoreConfiguration : IEntityTypeConfiguration<EventStore>
{
    public void Configure(EntityTypeBuilder<EventStore> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .IsRequired()
            .ValueGeneratedNever();

        builder.Property(e => e.AggregateId)
            .IsRequired();

        builder.Property(e => e.MessageType)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(e => e.Data)
            .IsRequired();

        builder.Property(e => e.OccurredOn)
            .IsRequired();
    }
}
