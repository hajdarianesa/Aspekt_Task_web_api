using Application.DTOs.Requests;
using Application.DTOs.Responses;
using MediatR;

namespace Application.Commands.Company;

public record UpdateCompanyCommand(int CompanyId, CompanyRequest CompanyRequest) : IRequest<CompanyResponse>;
