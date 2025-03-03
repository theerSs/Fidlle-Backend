using Fidlle.Application.IRepositories;
using Fidlle.Infrastructure.Repositories;

namespace Fidlle.Api.Extensions
{
    public static class RepositoriesExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            return services;
        }
    }
}