using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;
using CultureSpot.Application.Shared;

namespace CultureSpot.Application;

public static class Extensions
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ICommand<>).Assembly));
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ICommand).Assembly));

        services.AddClosedGenericTypes(typeof(ICommandHandler<>).Assembly, typeof(ICommandHandler<>), ServiceLifetime.Transient);
        services.RegisterGenericsAsItsParent(typeof(ICommandHandler<>), typeof(IRequestHandler<>));

        services.AddClosedGenericTypes(typeof(ICommandHandler<,>).Assembly, typeof(ICommandHandler<,>), ServiceLifetime.Transient);
        services.RegisterGenericsAsItsParent(typeof(ICommandHandler<,>), typeof(IRequestHandler<,>));

        return services;
    }

    public static IServiceCollection AddClosedGenericTypes(
    this IServiceCollection services,
    Assembly assembly,
    Type typeToRegister,
    ServiceLifetime serviceLifetime)
    {
        services.Scan(x => x.FromAssemblies(assembly)
            .AddClasses(classes => classes.AssignableTo(typeToRegister)
                .Where(t => !t.IsGenericType))
            .AsImplementedInterfaces(t => t.IsGenericType
                && t.GetGenericTypeDefinition() == typeToRegister)
            .WithLifetime(serviceLifetime));
        return services;
    }

    public static IServiceCollection RegisterGenericsAsItsParent(
    this IServiceCollection services,
    Type registeredGenericType,
    Type parentGenericType)
    {
        var registeredServiceDescriptors = services
            .Where(x => x.ServiceType.IsGenericType
                && x.ServiceType.GetGenericTypeDefinition()
                    == registeredGenericType)
            .ToArray();

        foreach (var serviceDescriptor in registeredServiceDescriptors)
        {
            var parentType = serviceDescriptor.ServiceType
                .GetInterfaces()
                .First(x => x.IsGenericType
                    && x.GetGenericTypeDefinition() == parentGenericType);
            services.Add(new ServiceDescriptor(parentType,
                sp => sp.GetRequiredService(serviceDescriptor.ServiceType),
                    serviceDescriptor.Lifetime));
        }

        return services;
    }
}