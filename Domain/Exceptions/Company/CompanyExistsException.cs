namespace Domain.Exceptions.Company;

public class CompanyExistsException : Exception
{
	public CompanyExistsException(string message) : base(message) { }
}
