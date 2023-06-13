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
    private readonly IOrganizerRepository _organizerRepository;

    public CreateEventHandler(IEventRepository eventRepository, IOrganizerRepository organizerReposiory) =>
        (_eventRepository, _organizerRepository) = (eventRepository, organizerReposiory);

    public async Task<Guid> Handle(CreateEvent request, CancellationToken cancellationToken)
    {
        var eventId = new EventId(Guid.NewGuid());
        var name = new Name(request.Name);
        var organizer = await _organizerRepository.GetByName(request.OrganizerName);

        if (organizer is null)
        {
            organizer = new Organizer(Guid.NewGuid(), request.OrganizerName, request.UserId);
        }

        var type = (EventType)request.Type;
        var description = new Description(request.Description);
        var schedule = new Schedule(Guid.NewGuid());

        foreach (var scheduleItem in request.Schedule)
        {
            schedule.AddScheduleItem(new ScheduleItem(
                                                Guid.NewGuid(), 
                                                schedule.ScheduleId, 
                                                scheduleItem.Date, 
                                                scheduleItem.StartTime, 
                                                scheduleItem.EndTime, 
                                                scheduleItem.Description
                                                ));
        }

        var location = new Location(request.Address);
        var price = new Price(request.Price);
        var capacity = new Capacity(request.Capacity);
        var date = DateOnly.Parse(request.Date);
        var imageUrl = new ImageUrl("images/default-poster.jpg");

        var newEvent = new Event(eventId, organizer, name, description, schedule, date, type, price, location, capacity, imageUrl);

        await _eventRepository.AddAsync(newEvent);

        return eventId;
    }
}
