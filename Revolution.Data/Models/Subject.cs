using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Revolution.Data;

public class Subject
{
    [Key]
    public long Id { get; set; }
    [Required]
    public string Name { get; set; } = String.Empty;
    public ICollection<Student> Students { get; set; }
}