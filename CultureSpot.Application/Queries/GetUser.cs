using CultureSpot.Application.DTO;
using MediatR;

namespace CultureSpot.Application.Queries;

public record GetUser() : IRequest<UserDto>
{
    public Guid UserId { get; set; }
}