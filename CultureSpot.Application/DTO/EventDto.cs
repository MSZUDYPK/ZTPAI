using CultureSpot.Core.Events.Enums;

namespace CultureSpot.Application.DTO;

public class EventDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public EventType Type { get; set; }
    public decimal Price { get; set; }
    public int Capacity { get; set; }
}
