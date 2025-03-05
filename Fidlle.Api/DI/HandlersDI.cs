using Fidlle.Api.Handlers;

namespace Fidlle.Api.DI
{
    public static class HandlersDI
    {
        public static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddExceptionHandler<ExceptionHandler>();

            return services;
        }
    }

}
