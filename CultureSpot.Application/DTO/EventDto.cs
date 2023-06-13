namespace CultureSpot.Application.DTO;

public class EventDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public DateOnly Date { get; set; }
    public string ImageUrl { get; set; }
}
