using MediatR;
using Microsoft.EntityFrameworkCore;
using CultureSpot.Application.DTO;
using CultureSpot.Infrastructure.DAL.Context;
using CultureSpot.Core.Events.ValueObjects;
using CultureSpot.Application.Queries;

namespace CultureSpot.Infrastructure.DAL.Handlers;

internal sealed class GetEventHandler : IRequestHandler<GetEvent, EventDetailsDto>
{
    private readonly CultureSpotDbContext _dbContext;

    public GetEventHandler(CultureSpotDbContext dbContext)
        => _dbContext = dbContext;

    public async Task<EventDetailsDto> Handle(GetEvent request, CancellationToken cancellationToken)
    {
        var eventId = new EventId(request.EventId);

        var eventEntity = await _dbContext.Events
        .Include(e => e.Schedule)
            .ThenInclude(s => s.ScheduleItems)
        .Include(e => e.Organizer)
        .SingleOrDefaultAsync(x => x.Id == eventId, cancellationToken);

        return eventEntity?.AsDetailsDto();
    }
}