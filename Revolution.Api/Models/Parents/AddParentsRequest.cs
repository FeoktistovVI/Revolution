namespace Revolution.Api.Models.Parents;

public class AddParentsRequest
{
    public long Id { get; set; }

    public long StudentId { get; set; }
    
    public string FirstName { get; set; } = String.Empty;
    
    public string LastName { get; set; } = String.Empty;
    
    public string Phone { get; set; } = String.Empty;
    
}