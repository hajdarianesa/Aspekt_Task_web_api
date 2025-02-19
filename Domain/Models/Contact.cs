using Domain.Abstractions.Entities;

namespace Domain.Models;

public class Contact : ISoftDeletable
{
	public int ContactId { get; set; }
	public string ContactName { get; set; } = string.Empty;
	public int CompanyId { get; set; }
	public int CountryId { get; set; }
	public bool IsDeleted { get; set; }
	public DateTime? DeletedOnUtc { get; set; }
}
