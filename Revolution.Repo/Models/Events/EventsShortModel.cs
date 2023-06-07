namespace Revolution.Repo.Models.Events;

public class EventsShortModel
{
    public long Id { get; set; }

    public string EventsName { get; set; } = string.Empty;
    
    public string EventsData { get; set; }

    public string VenueName { get; set; } = string.Empty;
    
    public long AreaId { get; set; }
    
}