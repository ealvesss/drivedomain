using System.Text.Json;
using DrivenDomain.Application.Dtos.Errors;
using Npgsql;

namespace DrivenDomain.Api.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (NpgsqlException ex)
            {
                var errorResponse = new ResponseError()
                {
                    Message = "An internal error occurred. Please try again later.",
                    StatusCode = "500"
                };

                _logger.LogError(ex, "Database error occurred.");
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
            }
        }
    }
}