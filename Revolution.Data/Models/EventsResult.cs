using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Revolution.Data.Models;

public class EventsResult
{
    [Key]
    public long Id { get; set; }
    [Required] 
    public long StudentId { get; set; }
    [ForeignKey("StudentId")]
    
    public string EventsResultName { get; set; } 
    
    public long CertificateNumber { get; set; }
    public long EventsId { get; set; }
    
}