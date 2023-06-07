using System.ComponentModel.DataAnnotations;

namespace Revolution.Data;

public class Area
{
    [Key]
    public long Id { get; set; }
    [Required]
    public string AreaName { get; set; } = String.Empty;
    
    public School Schools { get; set; }
    
    public ICollection<Events> Events { get; set; }
 }