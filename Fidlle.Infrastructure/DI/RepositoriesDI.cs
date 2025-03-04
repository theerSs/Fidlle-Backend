using Fidlle.Application.IRepositories;
using Fidlle.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Fidlle.Infrastructure.DI
{
    public static class RepositoriesDI
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>(); 
            return services;

        }
    }
}

