using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CultureSpot.Core.Users.Repositories;
using CultureSpot.Core.Events.Repositories;
using CultureSpot.Infrastructure.DAL.Repositories;
using CultureSpot.Core.Shared.Time;
using CultureSpot.Infrastructure.Auth;
using CultureSpot.Infrastructure.Security;
using CultureSpot.Infrastructure.Time;
using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;
using System.Reflection;
using CultureSpot.Application.Queries;
using CultureSpot.Infrastructure.DAL;

namespace CultureSpot.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.Configure<AppOptions>(configuration.GetRequiredSection("app"));
        services.AddHttpContextAccessor();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        services
            .AddScoped<IUserRepository, PostgresUserRepository>()
            .AddScoped<IEventRepository, PostgresEventRepository>()
            .AddSingleton<IClock, Clock>()
            .AddPostgres(configuration);

        services.AddSecurity();
        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(swagger =>
        {
            swagger.EnableAnnotations();
            swagger.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "CultureSpot API",
                Version = "v1"
            });
        });

        services.AddAuth(configuration);

        return services;
    }

    public static WebApplication UseInfrastructure(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "CultureSpot API v1"); });
        app.UseReDoc(reDoc =>
        {
            reDoc.RoutePrefix = "docs";
            reDoc.SpecUrl("/swagger/v1/swagger.json");
            reDoc.DocumentTitle = "CultureSpot API";
        });
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();

        return app;
    }

    public static T GetOptions<T>(this IConfiguration configuration, string sectionName) where T : class, new()
    {
        var options = new T();
        var section = configuration.GetRequiredSection(sectionName);
        section.Bind(options);

        return options;
    }
}