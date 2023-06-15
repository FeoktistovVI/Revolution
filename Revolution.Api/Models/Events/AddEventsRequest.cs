namespace Revolution.Api.Models.Events;

public class AddEventsRequest
{
    
    public long Id { get; set; }
   
    public string EventsName { get; set; } 

   
    public string EventsData { get; set; } 
    
    public string VenueName { get; set; }
   
    public long AreaId { get; set; }
}