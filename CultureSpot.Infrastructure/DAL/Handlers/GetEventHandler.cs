using MediatR;
using Microsoft.EntityFrameworkCore;
using CultureSpot.Application.DTO;
using CultureSpot.Infrastructure.DAL.Context;
using CultureSpot.Core.Events.ValueObjects;
using CultureSpot.Application.Queries;

namespace CultureSpot.Infrastructure.DAL.Handlers;

internal sealed class GetEventHandler : IRequestHandler<GetEvent, EventDto>
{
    private readonly CultureSpotDbContext _dbContext;

    public GetEventHandler(CultureSpotDbContext dbContext)
        => _dbContext = dbContext;

    public async Task<EventDto> Handle(GetEvent query, CancellationToken cancellationToken)
    {
        var eventId = new EventId(query.EventId);
        var eventObj = await _dbContext.Events
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.Id == eventId, cancellationToken: cancellationToken);

        return eventObj?.AsDto();
    }
}