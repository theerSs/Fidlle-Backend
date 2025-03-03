using Microsoft.AspNetCore.Antiforgery;

namespace Fidlle.Api.Middlewares
{
    public class AntiforgeryMiddleware(RequestDelegate next, IAntiforgery antiforgery) {
        public async Task InvokeAsync(HttpContext context)
        {
            if (HttpMethods.IsPost(context.Request.Method) ||
                HttpMethods.IsPut(context.Request.Method) ||
                HttpMethods.IsDelete(context.Request.Method))
            {
                await antiforgery.ValidateRequestAsync(context);
            }

            await next(context);
        }
    }
}
