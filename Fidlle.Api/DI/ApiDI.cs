namespace Fidlle.Api.DI
{
    public static class ApiDI
    {
        public static IServiceCollection AddApiLayer(this IServiceCollection services)
        {
            services.AddSession();
            services.AddHandlers();
            services.AddAntiforgery();
            return services;
        }
    }
}
