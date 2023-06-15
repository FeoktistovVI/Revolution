using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Revolution.Data.Models;

public class School
{
    [Key]
    public long Id { get; set; }
    [Required]
    public string Name { get; set; } 
    public long AreaId { get; set; }
    
}