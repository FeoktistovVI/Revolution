using System.ComponentModel.DataAnnotations;

namespace Revolution.Data;

public class EventsResult
{
    [Key]
    public long Id { get; set; }
    [Required] 
    public long StudentId { get; set; }
    public Student Student { get; set; }
    public string EventsResultName { get; set; } = String.Empty;
    
    public long CertificateNumber { get; set; }
    public long EventsId { get; set; }
    public Events Events { get; set; }
    public ICollection<Student> Students { get; set; }
}