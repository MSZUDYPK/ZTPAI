using CultureSpot.Application.DTO;
using MediatR;

namespace CultureSpot.Application.Queries;

public record GetEvent() : IRequest<EventDetailsDto>
{
    public Guid EventId { get; set; }
}
