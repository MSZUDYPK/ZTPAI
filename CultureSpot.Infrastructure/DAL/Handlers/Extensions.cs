using CultureSpot.Application.DTO;
using CultureSpot.Core.Events.Entities;
using CultureSpot.Core.Users.Entities;

namespace CultureSpot.Infrastructure.DAL.Handlers;

public static class Extensions
{
    public static UserDto AsDto(this User entity) => new()
    {
        Id = entity.Id,
        FirstName = entity.FirstName,
        LastName = entity.LastName
    };

    public static EventDto AsDto(this Event entity) => new()
    {
        Id = entity.Id,
        Name = entity.Name,
        Date = entity.Date,
        Location = entity.Location,
        ImageUrl = entity.ImageUrl
    };

    public static ScheduleItemDto AsDto(this ScheduleItem entity) => new()
    {
        Name = entity.Name,
        Description = entity.Description,
        StartTime = entity.StartTime,
        EndTime = entity.EndTime,
        Date = entity.Date,
    };

    public static ScheduleItemDto[] AsDto(this ICollection<ScheduleItem> entities)
    {
        return entities.Select(e => e.AsDto()).ToArray();
    }

    public static EventDetailsDto AsDetailsDto(this Event entity) => new()
    {
        Id = entity.Id,
        Name = entity.Name,
        Location = entity.Location,
        Date = entity.Date,
        ImageUrl = entity.ImageUrl,
        Organizer = entity.Organizer.Name,
        Schedule = entity.Schedule.ScheduleItems.AsDto(),
        Description = entity.Description,
        Type = entity.Type.ToString(),
        Price = entity.Price,
        Capacity = entity.Capacity
    };

}