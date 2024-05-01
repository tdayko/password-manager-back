using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using PasswordManager.Application.Mappers;
using PasswordManager.Application.Repositories;
using PasswordManager.Application.Services;
using PasswordManager.Infra.Configurations;
using PasswordManager.Infra.DbContext;
using PasswordManager.Infra.Repositories;
using PasswordManager.Infra.Services;

namespace PasswordManager.Infra;

public static class DependencyInjection
{
    public static IServiceCollection AddIoC(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICredentialRepository, CredentialRepository>();

        services.AddScoped<IJwtTokenService, JwtTokenService>();
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

        services.AddAutoMapper(typeof(AuthenticationMapping));
        services.AddAutoMapper(typeof(CredentialMapping));

        services.AddDbContext<PasswordManagerContext>();

        return services;
    }
}