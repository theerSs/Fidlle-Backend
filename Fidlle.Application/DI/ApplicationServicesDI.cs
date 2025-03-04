using Fidlle.Application.Service.Implementations;
using Fidlle.Application.Service.Interfaces;
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
