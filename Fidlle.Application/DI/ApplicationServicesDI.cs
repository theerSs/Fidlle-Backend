using Fidlle.Application.Services.Implementations;
using Fidlle.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Fidlle.Application.DI
{
    public static class ApplicationServicesDI
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IClaimsService, ClaimsService>();
            return services;
        }
    }
}
