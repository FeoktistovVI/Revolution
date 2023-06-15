using System.ComponentModel.DataAnnotations;

namespace Revolution.Data.Models;

public class Area
{
    [Key]
    public long Id { get; set; }
    [Required]
    public string AreaName { get; set; } 
    
    public ICollection<School> Schools { get; set; }
    
    public ICollection<Events> Events { get; set; }
 }