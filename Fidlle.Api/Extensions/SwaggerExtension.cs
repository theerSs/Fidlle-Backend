using Microsoft.OpenApi.Models;

namespace Fidlle.Api.Extensions
{
    public static class SwaggerExtension
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("cookieAuth", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.ApiKey,
                    Name = "Cookie",
                    In = ParameterLocation.Header,
                    Description = "Cookie-based authentication"
                });

                c.AddSecurityDefinition("X-CSRF-TOKEN", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.ApiKey,
                    Name = "X-CSRF-TOKEN",
                    In = ParameterLocation.Header,
                    Description = "CSRF token"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "cookieAuth"
                        }
                    },
                    Array.Empty<string>()
                },
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "X-CSRF-TOKEN"
                        }
                    },
                    Array.Empty<string>()
                }
            });
            });

            return services;
        }
    }

}
