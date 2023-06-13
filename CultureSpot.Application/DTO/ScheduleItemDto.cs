namespace CultureSpot.Application.DTO;

public class ScheduleItemDto
{
    public string Name { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public string Description { get; set; }
    public DateOnly Date { get; set; }
}

