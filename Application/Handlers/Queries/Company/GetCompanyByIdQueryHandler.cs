using Application.DTOs.Responses;
using Application.Queries.Company;
using Domain.Exceptions.GeneralException;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Queries.Company;

public class GetCompanyByIdQueryHandler : IRequestHandler<GetCompanyByIdQuery, CompanyResponse>
{
	private readonly ApplicationDbContext _context;

	public GetCompanyByIdQueryHandler(ApplicationDbContext context)
	{
		_context = context;
	}

	public async Task<CompanyResponse> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
	{
		var company = await _context.Companies
			.Where(c => c.CompanyId == request.CompanyId && !c.IsDeleted) 
			.Select(c => new CompanyResponse
			{
				CompanyId = c.CompanyId,
				CompanyName = c.CompanyName
			})
			.FirstOrDefaultAsync(cancellationToken);

		if (company == null)
		{
			throw new NotFoundException($"Company with ID {request.CompanyId} not found.");
		}
		return company;
	}
}