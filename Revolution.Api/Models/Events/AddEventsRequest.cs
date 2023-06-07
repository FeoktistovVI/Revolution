namespace Revolution.Api.Models.Events;

public class AddEventsRequest
{
    
    public long Id { get; set; }
   
    public string EventsName { get; set; } = String.Empty;

   
    public string EventsData { get; set; } = string.Empty;
    
    public string VenueName { get; set; } = String.Empty;
   
    public long AreaId { get; set; }
}