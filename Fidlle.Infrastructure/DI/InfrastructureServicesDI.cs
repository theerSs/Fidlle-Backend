using Fidlle.Infrastructure.Services;
using Fidlle.Shared.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Fidlle.Application.DI
{
    public static class InfrastructureServicesDI
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IPasswordService, PasswordService>();
            return services;
        }
    }
}
