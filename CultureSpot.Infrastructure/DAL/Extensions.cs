using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CultureSpot.Infrastructure.DAL.Context;
using CultureSpot.Infrastructure.DAL.Decorators;
using CultureSpot.Application.Shared;
using CultureSpot.Core.Users.Repositories;
using CultureSpot.Infrastructure.DAL.Repositories;
using MediatR;

namespace CultureSpot.Infrastructure.DAL;

internal static class Extensions
{
    public static IServiceCollection AddPostgres(this IServiceCollection services,
        IConfiguration configuration)
    {
        var section = configuration.GetRequiredSection("postgres");
        services.Configure<PostgresOptions>(section);
        var options = new PostgresOptions();
        section.Bind(options);
        services.AddDbContext<CultureSpotDbContext>(x => x.UseNpgsql(options.ConnectionString));

        services.AddScoped<IUnitOfWork, PostgresUnitOfWork>();

        services.TryDecorate(typeof(ICommandHandler<,>), typeof(UnitOfWorkCommandHandlerDecorator<,>));

        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        return services;
    }
}