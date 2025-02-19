using Application.DTOs.Responses;
using MediatR;

namespace Application.Commands.Company;

public record SoftDeleteCompanyCommand(int CompanyId) : IRequest<SoftDeleteResponse>;
