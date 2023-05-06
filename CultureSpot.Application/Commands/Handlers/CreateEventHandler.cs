using CultureSpot.Core.Events.Repositories;
using CultureSpot.Core.Events.Entities;
using CultureSpot.Core.Events.Enums;
using CultureSpot.Core.Events.ValueObjects;
using CultureSpot.Core.Shared.ValueObjects;
using CultureSpot.Application.Shared;

namespace CultureSpot.Application.Commands.Handlers;

internal sealed class CreateEventHandler : ICommandHandler<CreateEvent, Guid>
{
    private readonly IEventRepository _eventRepository;

    public CreateEventHandler(IEventRepository eventRepository) =>
        (_eventRepository) = (eventRepository);

    public async Task<Guid> Handle(CreateEvent request, CancellationToken cancellationToken)
    {
        var eventId = new EventId(Guid.NewGuid());
        var organizerId = new OrganizerId(Guid.NewGuid());
        var name = new Name(request.Name);
        var description = new Description(request.Description);
        var scheduleId = new ScheduleId(Guid.NewGuid());
        var type = (EventType)request.Type;
        var price = new Price(request.Price);
        var locationId = new LocationId(Guid.NewGuid());
        var capacity = new Capacity(request.Capacity);

        var newEvent = new Event(eventId, organizerId, name, description, scheduleId, type, price, locationId, capacity);

        await _eventRepository.AddAsync(newEvent);

        return eventId;
    }
}
