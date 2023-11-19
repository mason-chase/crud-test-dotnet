using Domain;

namespace Persistence.Configurations;

internal class CustomerConfiguration : object,
	Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Domain.Customer>
{
	public CustomerConfiguration() : base()
	{
	}

	public void Configure
		(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Domain.Customer> builder)
	{
		#region Property(ies) Configuration
		#endregion /Property(ies) Configuration

		#region Index(es) Configuration
		builder
			.HasKey(current => new { current.Id })
			;

		builder
			.HasIndex(current => new { current.Email })
			.IsUnique(unique: true);

		builder
			.HasIndex(current =>
				new
				{
					current.Firstname,
					current.Lastname,
					current.DateOfBirth
				})
			.IsUnique(unique: true);

		#endregion /Index(es) Configuration

		#region Relation(s) Configuration
		#endregion /Relation(s) Configuration

		#region Seed Data
		#endregion /Seed Data
	}
}
