using Application.DTOs.Requests;
using Application.DTOs.Responses;
using MediatR;

namespace Application.Commands.Company;

public record CreateCompanyCommand(CompanyRequest CompanyRequest) : IRequest<CompanyResponse>;

