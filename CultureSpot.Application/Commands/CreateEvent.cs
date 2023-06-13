using CultureSpot.Application.DTO;
using CultureSpot.Application.Shared;

namespace CultureSpot.Application.Commands;

public record CreateEventRequest(
        string Name,
        string OrganizerName,
        string Description,
        int Type,
        ScheduleItemDto[] Schedule,
        string Address,
        decimal Price,
        int Capacity,
        string Date
        ) : CommandBase<Guid>;

public record CreateEvent(
        string Name,
        string OrganizerName,
        string Description,
        int Type,
        ScheduleItemDto[] Schedule,
        string Address,
        decimal Price,
        int Capacity,
        string Date,
        Guid UserId
        ) : CommandBase<Guid>;