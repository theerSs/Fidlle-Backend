namespace Fidlle.Api.DI
{
    public static class AntiforgeryDI
    {
        public static IServiceCollection AddAntiforgery(this IServiceCollection services)
        {
          
            services.AddAntiforgery(options =>
            {
                options.HeaderName = "X-CSRF-TOKEN";
            });

            return services;
        }
    }
}
