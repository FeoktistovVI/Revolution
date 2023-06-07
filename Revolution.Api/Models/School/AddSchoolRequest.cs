namespace Revolution.Api.Models.School;

public class AddSchoolRequest
{
    public long Id { get; set; }
    
    public string Name { get; set; } = String.Empty;
    
    public long AreaId { get; set; }
}