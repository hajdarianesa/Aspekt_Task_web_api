using Application.Commands.Company;
using Application.DTOs.Responses;
using Domain.Exceptions.GeneralException;
using Infrastructure.Data;
using MediatR;

namespace Application.Handlers.Commands.Company;

public class SoftDeleteCompanyCommandHandler : IRequestHandler<SoftDeleteCompanyCommand, SoftDeleteResponse>
{
    private readonly ApplicationDbContext _context;

    public SoftDeleteCompanyCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<SoftDeleteResponse> Handle(SoftDeleteCompanyCommand request, CancellationToken cancellationToken)
    {
        var company = await _context.Companies.FindAsync(request.CompanyId);
        if (company == null)
        {
            throw new NotFoundException($"Company with ID {request.CompanyId} not found.");
        }

        company.IsDeleted = true;
        await _context.SaveChangesAsync(cancellationToken);

        return new SoftDeleteResponse
        {
            Message = $"Company '{company.CompanyName}' has been successfully deleted."
        };
    }
}