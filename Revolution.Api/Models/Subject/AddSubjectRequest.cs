namespace Revolution.Api.Models.Subject;

public class AddSubjectRequest
{
    public long Id { get; set; }
    
    public string Name { get; set; } = String.Empty;
}