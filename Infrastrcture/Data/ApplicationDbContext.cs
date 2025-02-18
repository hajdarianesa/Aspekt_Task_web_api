using Domain.Models;
using Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

	public DbSet<Company> Companies { get; set; }
	public DbSet<Contact> Contacts { get; set; }
	public DbSet<Country> Countries { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfiguration(new CompanyConfiguration());
		modelBuilder.ApplyConfiguration(new ContactConfiguration());
		modelBuilder.ApplyConfiguration(new CountryConfiguration());
	}
}
