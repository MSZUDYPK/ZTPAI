using CultureSpot.Application.DTO;
using MediatR;

namespace CultureSpot.Application.Queries;

public enum OrderByOptions
{
    None = 0,
    ByTitle = 1,
    ByDate = 2,
    ByAuthor = 3
}

public record GetEvents() : IRequest<IEnumerable<EventDto>>
{
    public OrderByOptions OrderBy { get; set; }
}
