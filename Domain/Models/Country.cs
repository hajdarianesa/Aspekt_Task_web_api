using Domain.Abstractions.Entities;

namespace Domain.Models;

public class Country : ISoftDeletable
{
	public int CountryId { get; set; }
	public string CountryName { get; set; } = string.Empty;
	public ICollection<Contact> Contacts { get; set; } = new List<Contact>();
	public bool IsDeleted { get; set; }
	public DateTime? DeletedOnUtc { get; set; }
}
