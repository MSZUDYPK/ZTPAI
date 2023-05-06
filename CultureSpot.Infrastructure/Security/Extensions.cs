using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using CultureSpot.Application.Security;
using CultureSpot.Core.Users.Entities;

namespace CultureSpot.Infrastructure.Security;

internal static class Extensions
{
    public static IServiceCollection AddSecurity(this IServiceCollection services)
    {
        services
            .AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>()
            .AddSingleton<IPasswordManager, PasswordManager>();

        return services;
    }
}