using System.ComponentModel.DataAnnotations;

namespace Revolution.Data.Models;

public class Parents
{
    [Key]
    public long Id { get; set; }
    [Required]
    public long StudentId { get; set; }
    
    public Student Student { get; set; }
    public string FirstName { get; set; } 
    public string LastName { get; set; } 
    public string Phone { get; set; } 

}