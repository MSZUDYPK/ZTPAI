namespace CultureSpot.Application.DTO;

public class EventDetailsDto : EventDto
{
    public string Organizer { get; set; }
    public string Description { get; set; }
    public ScheduleItemDto[] Schedule { get; set; }
    public string Type { get; set; }
    public decimal Price { get; set; }
    public int Capacity { get; set; }
}