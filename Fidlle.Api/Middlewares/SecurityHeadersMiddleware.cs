﻿namespace Fidlle.Api.Middlewares
{
    public class SecurityHeadersMiddleware
    {
        private readonly RequestDelegate _next;

        public SecurityHeadersMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Response.Headers.Append("X-Content-Type-Options", "nosniff"); 
            context.Response.Headers.Append("X-Frame-Options", "DENY"); 
            context.Response.Headers.Append("X-XSS-Protection", "1; mode=block"); 
            context.Response.Headers.Append("Referrer-Policy", "strict-origin-when-cross-origin"); 
            context.Response.Headers.Append("Permissions-Policy", "geolocation=(), microphone=()"); 
            context.Response.Headers.Append("Content-Security-Policy",
                "default-src 'self'; script-src 'self'; style-src 'self';");

            await _next(context);
        }
    }

}
