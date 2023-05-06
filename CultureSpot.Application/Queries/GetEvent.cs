using CultureSpot.Application.DTO;
using MediatR;

namespace CultureSpot.Application.Queries;

public record GetEvent() : IRequest<EventDto>
{
    public Guid EventId { get; set; }
}
