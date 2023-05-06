using CultureSpot.Application.DTO;
using MediatR;

namespace CultureSpot.Application.Queries;

public record GetUsers() : IRequest<IEnumerable<UserDto>>
{
}
