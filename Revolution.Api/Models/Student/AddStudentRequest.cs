namespace Revolution.Api.Models.Student;

public class AddStudentRequest
{
    public long Id { get; set; }
    
    public string FirstName { get; set; } = string.Empty;
    
    public string LastName { get; set; } = string.Empty;
    
    public string FatherName { get; set; } = string.Empty;

    public string DateOfBirth { get; set; } = string.Empty;
    
    public long Grade { get; set; }
    
    public long SchoolId { get; set; }
}