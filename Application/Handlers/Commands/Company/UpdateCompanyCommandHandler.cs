using Application.Commands.Company;
using Application.DTOs.Responses;
using Domain.Exceptions.Company;
using Domain.Exceptions.GeneralException;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Commands.Company;

public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, CompanyResponse>
{
    private readonly ApplicationDbContext _context;

    public UpdateCompanyCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CompanyResponse> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
    {
        var company = await _context.Companies.FindAsync(request.CompanyId);

        if (company == null)
        {
            throw new NotFoundException($"Company with ID {request.CompanyId} not found.");
        }

        var exists = await _context.Companies
            .AnyAsync(c => c.CompanyName == request.CompanyRequest.CompanyName && c.CompanyId != request.CompanyId, cancellationToken);

        if (exists)
        {
            throw new CompanyExistsException($"Company with name '{request.CompanyRequest.CompanyName}' already exists.");
        }

        company.CompanyName = request.CompanyRequest.CompanyName;
        await _context.SaveChangesAsync(cancellationToken);

        return new CompanyResponse
        {
            CompanyId = company.CompanyId,
            CompanyName = company.CompanyName
        };
    }
}
