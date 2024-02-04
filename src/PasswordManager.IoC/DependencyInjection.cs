using Microsoft.Extensions.DependencyInjection;

using PasswordManager.Application.Mapping;
using PasswordManager.Application.Persistence;
using PasswordManager.IoC.Persistence;

namespace PasswordManager.IoC;

public static partial class DependencyInjection
{
    public static IServiceCollection AddIoC(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddAutoMapper(typeof(AuthMapping));
        return services;
    }
}