using System.ComponentModel.DataAnnotations;

namespace Revolution.Data.Models;

public class Events
{
    [Key]
    public long Id { get; set; }
    [Required]
    public string EventsName { get; set; } 

    public string EventsData { get; set; }
    public string VenueName { get; set; } 
    public long AreaId { get; set; }
    
    public ICollection<EventsResult> EventsResults { get; set; }
}