using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Revolution.Data;

public class School
{
    [Key]
    public long Id { get; set; }
    [Required]
    public string Name { get; set; } = String.Empty;
    public long AreaId { get; set; }
    public Area Area { get; set; }
    public ICollection<Student> Students { get; set; }
}