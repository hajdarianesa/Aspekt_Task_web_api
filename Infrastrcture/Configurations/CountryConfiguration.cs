using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
	public void Configure(EntityTypeBuilder<Country> builder)
	{
		builder.HasKey(c => c.CountryId);
		builder.Property(c => c.CountryName)
			   .IsRequired()
			   .HasMaxLength(100);
	}
}
