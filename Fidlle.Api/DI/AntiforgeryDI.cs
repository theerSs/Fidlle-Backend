using Microsoft.AspNetCore.Authentication.Cookies;

namespace Fidlle.Api.Extensions
{
    public static class AntiforgeryDI
    {
        public static IServiceCollection AddAntiforgery(this IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/api/account/login";
                    options.LogoutPath = "/api/account/logout";
                    options.AccessDeniedPath = "/api/account/access-denied";
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                    options.SlidingExpiration = true;
                });

            services.AddAntiforgery(options =>
            {
                options.HeaderName = "X-CSRF-TOKEN";
            });

            return services;
        }
    }
}
