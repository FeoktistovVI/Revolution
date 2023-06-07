namespace Revolution.Api.Models.EventsResult;

public class AddEventsResultRequest
{
    public long Id { get; set; } 
    
    public long StudentId { get; set; }

    public string EventsResultName { get; set; } = string.Empty;
    
    public long CertificateNumber { get; set; }
    
    public long EventsId { get; set; }
}