using Microsoft.AspNetCore.Authentication.Cookies;

namespace Fidlle.Api.DI
{
    public static class SessionExtensions
    {
        public static IServiceCollection AddSession(this IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
              .AddCookie(options =>
              {
                  options.LoginPath = "/api/account/login";
                  options.LogoutPath = "/api/account/logout";
                  options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                  options.SlidingExpiration = true;
                  options.Events.OnRedirectToLogin = context =>
                  {
                      context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                      return Task.CompletedTask;
                  };
              });

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            return services;
        }
    }

}
