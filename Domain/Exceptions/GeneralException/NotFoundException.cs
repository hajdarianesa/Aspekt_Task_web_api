namespace Domain.Exceptions.GeneralException;

public class NotFoundException : Exception
{
	public NotFoundException(string message) : base(message) { }
}
