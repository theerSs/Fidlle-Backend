using Fidlle.Application.DTO;
using Fidlle.Application.Validators;
using FluentValidation.AspNetCore;
using FluentValidation;

namespace Fidlle.Api.Extensions
{
    public static class ValidatorsExtension
    {
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
            services.AddTransient<IValidator<RegisterDto>, RegisterDtoValidator>();
            services.AddTransient<IValidator<LoginDto>, LoginDtoValidator>();

            return services;
        }
    }

}
