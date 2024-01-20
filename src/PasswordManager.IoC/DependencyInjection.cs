using Microsoft.Extensions.DependencyInjection;
using PasswordManager.Application.Persistence;
using PasswordManager.IoC.Persistence;
using MediatR;

namespace PasswordManager.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddIoC(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddMediatR(typeof(DependencyInjection).Assembly);
        return services;
    }
}