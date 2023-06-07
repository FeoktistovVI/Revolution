using Revolution.Repo.Models.Student;

namespace Revolution.Repo.Interfaces;

public interface IStudent
{
    Task<StudentShortModel> Add(long id, string firstName, string lastName, string dateOfBirth, string fatherName,
        long grade, long schoolId);

    Task<SearchStudentResponse> SearchStudents(StudentGetModel model);

    Task<GetStudentResponse> GetStudentAsync(GetStudentRequest request);
    
    Task Update(long id, string firstName, string lastName, string dateOfBirth, string fatherName, long grade,
        long schoolId);
    
    Task Remove(long id);
}