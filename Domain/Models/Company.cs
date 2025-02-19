using Domain.Abstractions.Entities;

namespace Domain.Models;

public class Company : ISoftDeletable
{
	public int CompanyId { get; set; }
	public string CompanyName { get; set; } = string.Empty;
	public ICollection<Contact> Contacts { get; set; } = new List<Contact>();
	public bool IsDeleted { get; set; }
	public DateTime? DeletedOnUtc { get; set; }
}
