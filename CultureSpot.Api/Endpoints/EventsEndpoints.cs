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

        eventsEndpoints.MapGet("{eventId:guid}", (Guid eventId, IMediator mediator) => GetById(eventId, mediator))
                       .Produces<EventDetailsDto>(StatusCodes.Status200OK)
                       .WithName("GetEventById")
                       .WithTags("Event Getters");

        eventsEndpoints.MapPost("", (CreateEventRequest request, IMediator mediator, IHttpContextAccessor httpContextAccessor) => Create(request, mediator, httpContextAccessor))
                       .Produces(StatusCodes.Status201Created)
                       .WithName("CreateNewEvent")
                       .WithTags("Event Setters");

        eventsEndpoints.MapPut("{eventId:guid}", async (Guid eventId, HttpRequest request, IMediator mediator) =>
        {
            if (!request.HasFormContentType)
            {
                return Results.BadRequest("Invalid content type. Expected 'multipart/form-data'.");
            }

            var form = await request.ReadFormAsync();
            var file = form.Files.GetFile("file");

            if (file is null || file.Length == 0)
            {
                return Results.BadRequest("No file is uploaded.");
            }

            var command = new UploadEventImage(eventId, file);

            await mediator.Send(command);

            return Results.Ok("File uploaded successfully.");
        })
            .Produces(StatusCodes.Status200OK)
            .Accepts<IFormFile>("multipart/form-data")
            .WithName("UploadEventImage")
            .WithTags("Event Setters");

        return eventsEndpoints;
    }

    private static async Task<IResult> Get(IMediator mediator)
        => Results.Ok(await mediator.Send(new GetEvents()));

    private static async Task<IResult> GetById(Guid eventId, IMediator mediator)
    {
        var eventResult = await mediator.Send(new GetEvent() { EventId = eventId });

        return eventResult is not null ? Results.Ok(eventResult) : Results.NotFound();
    }

    private static async Task<IResult> Create(CreateEventRequest request, IMediator mediator, IHttpContextAccessor httpContextAccessor)
    {
        if (string.IsNullOrWhiteSpace(httpContextAccessor.HttpContext.User.Identity?.Name))
        {
            return Results.BadRequest();
        }

        var userId = Guid.Parse(httpContextAccessor.HttpContext.User.Identity.Name);

        var command = new CreateEvent 
        (
            request.Name,
            request.OrganizerName,
            request.Description,
            request.Type,
            request.Schedule,
            request.Address,
            request.Price,
            request.Capacity,
            request.Date,
            userId
        );

        var eventId = await mediator.Send(command);
        return Results.Created("api/events/{eventId:Guid}", eventId);
    }
}