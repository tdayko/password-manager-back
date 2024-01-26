using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace PasswordManager.Application;

public static partial class DependencyInjection
{
    public static IServiceCollection AddMediatR(this IServiceCollection services)
    {
        services.AddMediatR(typeof(DependencyInjection).Assembly);
        return services;
    }
}