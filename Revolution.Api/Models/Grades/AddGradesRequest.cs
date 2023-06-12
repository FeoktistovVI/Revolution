namespace Revolution.Api.Models.Grades;

public class AddGradesRequest
{
    public long Id { get; set; }
    
    public long StudentId { get; set; }
    
    public long SubjectId { get; set; }
    
    public long Grade { get; set; }

    public string Date { get; set; } = string.Empty;


}