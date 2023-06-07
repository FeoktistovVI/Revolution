using System.ComponentModel.DataAnnotations;

namespace Revolution.Data;

public class Parents
{
    [Key]
    public long Id { get; set; }
    [Required]
    public long StudentId { get; set; }
    
    public Student Student { get; set; }
    public string FirstName { get; set; } = String.Empty;
    public string LastName { get; set; } = String.Empty;
    public string Phone { get; set; } = String.Empty;

}