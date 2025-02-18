using System.Net;
using System.Text.Json;
using Domain.Exceptions.Company;

namespace Aspekt_Task_web_api.Middlewares;

/// <summary>
/// Middleware to handle exceptions globally and return appropriate HTTP responses.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="ExceptionHandlingMiddleware"/> class.
/// </remarks>
/// <param name="next">The next middleware in the pipeline.</param>
/// <param name="logger">The logger instance to log errors.</param>
public class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
{
	private readonly RequestDelegate _next = next;
	private readonly ILogger<ExceptionHandlingMiddleware> _logger = logger;

	private static readonly Dictionary<Type, HttpStatusCode> ExceptionStatusCodes = new()
	{
        { typeof(CompanyExistsException), HttpStatusCode.NotFound }
	};

	/// <summary>
	/// Invokes the middleware to handle exceptions.
	/// </summary>
	/// <param name="context">The current HTTP context.</param>
	public async Task InvokeAsync(HttpContext context)
	{
		try
		{
			await _next(context);
		}
		catch (Exception ex)
		{
			await HandleExceptionAsync(context, ex);
		}
	}

	/// <summary>
	/// Handles the exception by returning a JSON error response.
	/// </summary>
	/// <param name="context">The current HTTP context.</param>
	/// <param name="exception">The exception that was thrown.</param>
	private async Task HandleExceptionAsync(HttpContext context, Exception exception)
	{
		context.Response.ContentType = "application/json";

		var statusCode = ExceptionStatusCodes.TryGetValue(exception.GetType(), out var code)
			? code
			: HttpStatusCode.InternalServerError; 

		context.Response.StatusCode = (int)statusCode;
		_logger.LogError(exception, "Exception: {Message}", exception.Message);

		var response = new
		{
			message = exception.Message
		};

		await context.Response.WriteAsync(JsonSerializer.Serialize(response));
	}
}
