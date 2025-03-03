using Fidlle.Application.UseCases.Implementations;
using Fidlle.Application.UseCases.Interfaces;

namespace Fidlle.Api.Extensions
{
    public static class UseCasesExtension
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddTransient<IAccountUseCases, AccountUseCases>();
            return services;
        }
    }
}