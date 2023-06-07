using Revolution.Data;
using Revolution.Repo.Models.Subject;

namespace Revolution.Repo.Interfaces;

public interface ISubject
{
    Task<Subject> Add(long id,string name);

    Task<SearchSubjectResponse> SearchSubject(SubjectGetModel model);

    Task<GetSubjectResponse> GetSubjectAsync(GetSubjectRequest request);
    
    Task Update(long id, string name);
    
    Task DeleteSubjectAsync(long id);
}