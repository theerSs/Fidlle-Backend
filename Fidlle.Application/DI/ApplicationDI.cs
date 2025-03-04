using Microsoft.Extensions.DependencyInjection;

namespace Fidlle.Application.DI
{
    public static class ApplicationDI
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddApplicationServices();
            services.AddValidators();
            return services;
        }
    }
}
