using CultureSpot.Application.Commands;
using CultureSpot.Application.DTO;
using CultureSpot.Application.Queries;
using MediatR;

namespace CultureSpot.Api.Endpoints;

internal static class EventsEndpoints
{
    public static IEndpointRouteBuilder MapEventsEndpoints(this IEndpointRouteBuilder app)
    {
        var eventsEndpoints = app.MapGroup("api/events");

        eventsEndpoints.MapGet("", Get)
                       .Produces<EventDto>(StatusCodes.Status200OK)
                       .WithName("GetAllEvents")
                       .WithTags("Event Getters");

        eventsEndpoints.MapGet("{eventId:Guid}", (Guid eventId, IMediator mediator) => GetById(eventId, mediator))
                       .Produces<EventDto>(StatusCodes.Status200OK)
                       .WithName("GetEventById")
                       .WithTags("Event Getters");

        eventsEndpoints.MapPost("", (CreateEvent command, IMediator mediator) => Create(command, mediator))
                       .Produces(StatusCodes.Status201Created)
                       .WithName("CreateNewEvent")
                       .WithTags("Event Setters");

        /*eventsEndpoints.MapPut("", Update);*/

        return eventsEndpoints;
    }

    private static async Task<IResult> Get(IMediator mediator)
        => Results.Ok(await mediator.Send(new GetEvents()));

    private static async Task<IResult> GetById(Guid eventId, IMediator mediator)
    {
        var eventResult = await mediator.Send(new GetEvent() { EventId = eventId });

        return eventResult is not null ? Results.Ok(eventResult) : Results.NotFound();
    }

    private static async Task<IResult> Create(CreateEvent command, IMediator mediator)
    {
        var eventId = await mediator.Send(command);
        return Results.Created("api/events/{eventId:Guid}", eventId);
    }

    /* private static async Task<IResult> Update(Guid EventId, IMediator mediator);*/
}