using Microsoft.EntityFrameworkCore;
using PublishingHouse.Interfaces.Extensions.Pagination;
using Revolution.Data;
using Revolution.Data.Models;
using Revolution.Repo.Enums;
using Revolution.Repo.Interfaces;
using Revolution.Repo.Models;
using Revolution.Repo.Models.Student;

namespace Revolution.Repo.Services;

public class StudentService : IStudent
{
    private readonly AplicationContext _db;

    public StudentService(AplicationContext db)
    {
        _db = db;
    }
    public async Task<StudentShortModel> Add(long id, string firstName, string lastName, string dateOfBirth,
        string fatherName, long grade, long schoolId)
    {
        if (await _db.Students.FirstOrDefaultAsync(x => x.Id != id)!=null)
            throw new TirException($"Student {id} is not exists!", EnumErrorCode.EntityIsNotFound);
		
        var student = new Student
        {
			
            Id = id,
            FirstName = firstName,
            LastName = lastName,
            DateOfBirth = dateOfBirth,
            FatherName = fatherName,
            Grade = grade,
            SchoolId = schoolId
            
        };		
        await _db.AddAsync(student);
        await _db.SaveChangesAsync();

        return new StudentShortModel
        {
            Id = student.Id,
            FirstName = student.FirstName,
            LastName = student.LastName,
            DateOfBirth = student.DateOfBirth,
            FatherName = student.FatherName,
            Grade = student.Grade,
            SchoolId = student.SchoolId
        };
    }

    public async Task<SearchStudentResponse> SearchStudents(StudentGetModel model)
    {
        return await _db.Students
            .Where(x =>
                x.FirstName.Contains(model.Search)
                || x.LastName.Contains(model.Search)
            ).GetPageAsync<SearchStudentResponse, Student, StudentShortModel>(model, x => new StudentShortModel
            {
                Id =x.Id,
                FirstName =x.FirstName,
                LastName = x.LastName,
                DateOfBirth= x.DateOfBirth,
                FatherName = x.FatherName,
                Grade = x.Grade,
                SchoolId = x.SchoolId
            });
    }

    public async Task<GetStudentResponse> GetStudentAsync(GetStudentRequest request)
    {
        return await _db.Students.GetPageAsync<GetStudentResponse, Student, StudentShortModel>(request, student =>
            new StudentShortModel
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                FatherName = student.FatherName,
                DateOfBirth = student.DateOfBirth,
                Grade  = student.Grade,
                SchoolId = student.SchoolId
				
            });
    }

    public async Task Update(long id, string firstName, string lastName, string dateOfBirth, string fatherName,
        long grade, long schoolId)
    {
        var student = await _db.Students.FirstOrDefaultAsync(x => x.Id == id);
        if (student is null)
            throw new TirException($"Student Id = {id} is not found!", EnumErrorCode.EntityIsNotFound);

        if (!string.IsNullOrWhiteSpace(firstName))
            student.FirstName = firstName;
        
        if (!string.IsNullOrWhiteSpace(lastName))
            student.LastName = lastName;
        
        if (!string.IsNullOrWhiteSpace(fatherName))
            student.FatherName = fatherName;
        
        if (!string.IsNullOrWhiteSpace(dateOfBirth))
            student.DateOfBirth = dateOfBirth;
        
        if (schoolId > 0)
        {
            if (await _db.Students.AllAsync(x => x.Id != schoolId))
                throw new TirException($"SchoolId {schoolId} is not exists!", EnumErrorCode.EntityIsNotFound);
            student.SchoolId = schoolId;
        }
        await _db.SaveChangesAsync();
    }
    

    public async Task Remove(long id)
    {
        if (await _db.Students.AllAsync(x => x.Id != id))
            throw new TirException($"Students id = {id} is not exists!",EnumErrorCode.EntityIsNotFound);

	
        _db.Students.Remove(new Student { Id = id });
        await _db.SaveChangesAsync();
    }
}