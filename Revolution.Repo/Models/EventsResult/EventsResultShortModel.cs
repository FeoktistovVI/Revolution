namespace Revolution.Repo.Models.EventsResult;

public class EventsResultShortModel
{
    public long Id { get; set; }
    
    public long StudentId { get; set; }
    
    public string EventsResultName { get; set; } = String.Empty;
    
    public long CertificateNumber { get; set; }
    
    public long EventsId { get; set; }
    
}