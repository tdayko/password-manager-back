using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using PasswordManager.Application.Authentication;
using PasswordManager.Application.Mapping;
using PasswordManager.Application.Persistence;
using PasswordManager.IoC.Authentication;
using PasswordManager.IoC.Persistence;

namespace PasswordManager.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddIoC(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddAutoMapper(typeof(DomainMapping));

        return services;
    }
};