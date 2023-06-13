using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CultureSpot.Infrastructure.DAL.Context;
using CultureSpot.Infrastructure.DAL.Decorators;
using CultureSpot.Application.Shared;
using CultureSpot.Core.Users.Repositories;
using CultureSpot.Infrastructure.DAL.Repositories;
using CultureSpot.Application.Commands.Handlers;
using MediatR;
using CultureSpot.Application.Commands;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace CultureSpot.Infrastructure.DAL;

internal static class Extensions
{
    private const string OptionsSectionName = "postgres";

    public static IServiceCollection AddPostgres(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<PostgresOptions>(configuration.GetRequiredSection(OptionsSectionName));
        var postgresOptions = configuration.GetOptions<PostgresOptions>(OptionsSectionName);
        services.AddDbContext<CultureSpotDbContext>(x => x.UseNpgsql(postgresOptions.ConnectionString));
        services.AddScoped<IUnitOfWork, PostgresUnitOfWork>();

        services.TryDecorate(typeof(ICommandHandler<,>), typeof(UnitOfWorkCommandHandlerDecorator<,>));
        services.TryDecorate(typeof(ICommandHandler<>), typeof(UnitOfWorkCommandHandlerDecorator<>));

        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        return services;
    }
}