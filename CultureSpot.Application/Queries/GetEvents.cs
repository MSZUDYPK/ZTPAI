using CultureSpot.Application.DTO;
using MediatR;

namespace CultureSpot.Application.Queries;

public enum OrderByOptions
{
    None = 0,
    Relevance = 1,
    Popularity = 2,
    Newest = 3
}

public record GetEvents() : IRequest<IEnumerable<EventDto>>
{
    public OrderByOptions OrderBy { get; set; }
}
