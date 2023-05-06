using Microsoft.Extensions.Options;
using CultureSpot.Application;
using CultureSpot.Core;
using CultureSpot.Infrastructure;
using System.Reflection;
using CultureSpot.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddCoreLayer()
    .AddApplicationLayer()
    .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()))
    .AddInfrastructureLayer(builder.Configuration);
    
var app = builder.Build();

app.UseInfrastructure();
app.MapGet("api", (IOptions<AppOptions> options) => Results.Ok(options.Value.Name));
app.MapEventsEndpoints();
app.MapUsersEndpoints();
app.Run();
