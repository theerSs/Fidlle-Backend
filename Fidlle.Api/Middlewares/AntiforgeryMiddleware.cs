using Microsoft.AspNetCore.Antiforgery;
using Fidlle.Shared.Exceptions;

namespace Fidlle.Api.Middlewares
{
    public class AntiforgeryMiddleware(RequestDelegate next, IAntiforgery antiforgery) {
        public async Task InvokeAsync(HttpContext context)
        {
            if (HttpMethods.IsPost(context.Request.Method) ||
                HttpMethods.IsPut(context.Request.Method) ||
                HttpMethods.IsDelete(context.Request.Method))
            {
                try
                {
                    await antiforgery.ValidateRequestAsync(context);
                }
                catch (AntiforgeryValidationException)
                {
                    throw new ForbidException("Antiforgery token validation failed.");
                }
            }

            await next(context);
        }
    }
}
