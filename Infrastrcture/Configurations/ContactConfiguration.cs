using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class ContactConfiguration : IEntityTypeConfiguration<Contact>
{
	public void Configure(EntityTypeBuilder<Contact> builder)
	{
		builder.HasKey(c => c.ContactId);
		builder.Property(c => c.ContactName)
			   .IsRequired()
			   .HasMaxLength(100);

		builder.HasOne<Company>()
			   .WithMany(c => c.Contacts)
			   .HasForeignKey(c => c.CompanyId);

		builder.HasOne<Country>()
			   .WithMany(c => c.Contacts)
			   .HasForeignKey(c => c.CountryId);
	}
}
