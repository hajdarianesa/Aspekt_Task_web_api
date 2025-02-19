using Application.DTOs.Responses;
using MediatR;

namespace Application.Queries.Company;

public record GetAllCompaniesQuery : IRequest<List<CompanyResponse>>;
