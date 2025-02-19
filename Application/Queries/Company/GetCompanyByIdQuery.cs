using Application.DTOs.Responses;
using MediatR;

namespace Application.Queries.Company;

public record GetCompanyByIdQuery(int CompanyId) : IRequest<CompanyResponse>;
