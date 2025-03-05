using Fidlle.Shared.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace Fidlle.Api.Handlers
{
    public class ExceptionHandler(ILogger<ExceptionHandler> logger) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            (int statusCode, string errorMessage) = exception switch
            {
                ForbidException forbidException => (StatusCodes.Status403Forbidden, forbidException.Message ?? "You do not have permission to access this resource."),
                UnauthorizedAccessException unauthorizedAccessException => (StatusCodes.Status401Unauthorized, unauthorizedAccessException.Message ?? "Authentication is required to access this resource."),
                NotFoundException notFoundException => (StatusCodes.Status404NotFound, notFoundException.Message ?? "The requested resource was not found."),
                BadRequestException badRequestException => (StatusCodes.Status400BadRequest, badRequestException.Message ?? "The request could not be processed. Please check the input."),
                _ => (StatusCodes.Status500InternalServerError, "An unexpected error occured!")
            };

          
            logger.LogError(exception, exception.Message);
         
            httpContext.Response.StatusCode = statusCode;
            await httpContext.Response.WriteAsJsonAsync(errorMessage, cancellationToken);

            return true;
        }
    }
}
