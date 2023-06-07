namespace Revolution.Repo.Models.Grades;

public class GradesShortModel
{
    public long Id { get; set; }
    
    public long SubjectId { get; set; }
    
    public  long StudentId { get; set; }
    public long Grade { get; set; }
    
    public string Date { get; set; }
    
}