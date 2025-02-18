using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
	public void Configure(EntityTypeBuilder<Company> builder)
	{
		builder.HasKey(c => c.CompanyId);
		builder.Property(c => c.CompanyName)
			   .IsRequired()
			   .HasMaxLength(100);

		builder.HasMany(c => c.Contacts)
			   .WithOne()
			   .HasForeignKey(c => c.CompanyId)
			   .OnDelete(DeleteBehavior.Cascade);
	}
}
