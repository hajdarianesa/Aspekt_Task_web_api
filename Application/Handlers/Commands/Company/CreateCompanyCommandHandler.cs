using Application.Commands.Company;
using Application.DTOs.Responses;
using Domain.Exceptions.Company;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Commands.Company;

public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, CompanyResponse>
{
    private readonly ApplicationDbContext _context;

    public CreateCompanyCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CompanyResponse> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        var companyExists = await _context.Companies
            .AnyAsync(c => c.CompanyName == request.CompanyRequest.CompanyName, cancellationToken);

        if (companyExists)
        {
            throw new CompanyExistsException($"Company with name '{request.CompanyRequest.CompanyName}' already exists.");
        }

        var company = new Domain.Models.Company
        {
            CompanyName = request.CompanyRequest.CompanyName
        };

        _context.Companies.Add(company);
        await _context.SaveChangesAsync(cancellationToken);

        return new CompanyResponse
        {
            CompanyId = company.CompanyId,
            CompanyName = company.CompanyName
        };
    }
}
