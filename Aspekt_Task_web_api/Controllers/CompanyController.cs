using Application.Commands.Company;
using Application.DTOs.Requests;
using Application.Queries.Company;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Aspekt_Task_web_api.Controllers;

[Route("api/company")]
[ApiController]
public class CompanyController : ControllerBase
{
	private readonly IMediator _mediator;

	public CompanyController(IMediator mediator)
	{
		_mediator = mediator;
	}
	[HttpPost]
	public async Task<IActionResult> Create([FromBody] CompanyRequest request)
	{
		var response = await _mediator.Send(new CreateCompanyCommand(request));
		return CreatedAtAction(nameof(GetById), new { id = response.CompanyId }, response);
	}
	[HttpGet]
	public async Task<IActionResult> GetAll()
	{
		var response = await _mediator.Send(new GetAllCompaniesQuery());
		return Ok(response);
	}
	[HttpGet("{id}")]
	public async Task<IActionResult> GetById(int id)
	{
		var response = await _mediator.Send(new GetCompanyByIdQuery(id));
		return Ok(response);
	}
	[HttpPut("{id}")]
	public async Task<IActionResult> Update(int id, [FromBody] CompanyRequest request)
	{
		var response = await _mediator.Send(new UpdateCompanyCommand(id, request));
		return Ok(response);
	}
	[HttpDelete("{id}")]
	public async Task<IActionResult> SoftDelete(int id)
	{
		var response = await _mediator.Send(new SoftDeleteCompanyCommand(id));
		return Ok(response);
	}

}