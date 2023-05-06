using CultureSpot.Application.DTO;
using CultureSpot.Core.Events.Entities;
using CultureSpot.Core.Users.Entities;

namespace CultureSpot.Infrastructure.DAL.Handlers;

public static class Extensions
{
    public static UserDto AsDto(this User entity) => new()
    {
        Id = entity.Id,
        Username = entity.Username,
        FirstName = entity.FirstName,
        LastName = entity.LastName
    };

    public static EventDto AsDto(this Event entity) => new()
    {
        Id = entity.Id,
        Name = entity.Name
    };
}