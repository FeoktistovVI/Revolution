using System.ComponentModel.DataAnnotations;

namespace Revolution.Data;

public class Events
{
    [Key]
    public long Id { get; set; }
    [Required]
    public string EventsName { get; set; } = String.Empty;

    public string EventsData { get; set; } = string.Empty;
    public string VenueName { get; set; } = String.Empty;
    public long AreaId { get; set; }
    
    public Area Area { get; set; }
}