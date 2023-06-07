using Revolution.Repo.Models.Grades;

namespace Revolution.Repo.Interfaces;

public interface IGrades
{
    Task<GradesShortModel> Add(long id, long subjectId, long studentId ,long grade, string date);

    Task<SearchGradesResponse> SearchGrades(GradesGetModel model);

    Task<GetGradesResponse> GetGradesAsync(GetGradesRequest request);
    
    Task Update(long id, long subjectId,long studentId ,long grade, string date);
    
    Task Remove(long id);
}