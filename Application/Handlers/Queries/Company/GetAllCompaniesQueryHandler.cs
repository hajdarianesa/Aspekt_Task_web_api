using Application.DTOs.Responses;
using Application.Queries.Company;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Queries.Company;

public class GetAllCompaniesQueryHandler : IRequestHandler<GetAllCompaniesQuery, List<CompanyResponse>>
{
	private readonly ApplicationDbContext _context;

	public GetAllCompaniesQueryHandler(ApplicationDbContext context)
	{
		_context = context;
	}

	public async Task<List<CompanyResponse>> Handle(GetAllCompaniesQuery request, CancellationToken cancellationToken)
	{
		var companies = await _context.Companies
			.Where(c => !c.IsDeleted)
			.Select(c => new CompanyResponse
			{
				CompanyId = c.CompanyId,
				CompanyName = c.CompanyName
			})
			.ToListAsync(cancellationToken);

		return companies;
	}
}
