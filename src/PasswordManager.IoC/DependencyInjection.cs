using Microsoft.Extensions.DependencyInjection;
using PasswordManager.Application.Persistence;
using PasswordManager.IoC.Persistence;

namespace PasswordManager.IoC;

public static partial class DependencyInjection
{
    public static IServiceCollection AddIoC(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}