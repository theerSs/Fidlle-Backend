namespace Fidlle.Api.Extensions
{
    public static class ApiDI
    {
        public static IServiceCollection AddApiLayer(this IServiceCollection services)
        {
            services.AddSession();
            services.AddAntiforgery();
            return services;
        }
    }
}
