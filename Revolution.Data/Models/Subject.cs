using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Revolution.Data.Models;

public class Subject
{
    [Key]
    public long Id { get; set; }
    [Required]
    public string Name { get; set; } 

}