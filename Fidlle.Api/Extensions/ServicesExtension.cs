using Fidlle.Application.Service.Implementations;
using Fidlle.Application.Service.Interfaces;

namespace Fidlle.Api.Extensions
{
    public static class ServicesExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IClaimsService, ClaimsService>();
            return services;
        }
    }

}
