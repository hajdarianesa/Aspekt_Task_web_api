namespace Domain.Abstractions.Entities;

public interface ISoftDeletable
{
	bool IsDeleted { get; set; }
	DateTime? DeletedOnUtc { get; set; }
}
