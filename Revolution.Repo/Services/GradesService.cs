using Microsoft.EntityFrameworkCore;
using PublishingHouse.Interfaces.Extensions.Pagination;
using Revolution.Data;
using Revolution.Data.Models;
using Revolution.Repo.Enums;
using Revolution.Repo.Interfaces;
using Revolution.Repo.Models;
using Revolution.Repo.Models.Grades;

namespace Revolution.Repo.Services;

public class GradesService : IGrades
{
    private readonly AplicationContext _db;

    public GradesService(AplicationContext db)
    {
        _db = db;
    }

    public async Task<GradesShortModel> Add(long id, long subjectId, long studentId , long grade, string date)
    {
        if (await _db.Grades.FirstOrDefaultAsync(x => x.Id != id)!=null)
            throw new TirException($"Grades {id} is not exists!", EnumErrorCode.EntityIsNotFound);
		
        var grades = new Grades
        {
            Id = id,
            SubjectId = subjectId,
            Date = date,
            Grade = grade,
            StudentId = studentId

        };		
        await _db.AddAsync(grades);
        await _db.SaveChangesAsync();

        return new GradesShortModel
        {
            Id = grades.Id,
            SubjectId = grades.SubjectId,
            Date = grades.Date,
            Grade = grades.Grade,
            StudentId = grades.StudentId
        };
    }
    
    public async Task<SearchGradesResponse> SearchGrades(GradesGetModel model)
    {
        return await _db.Grades
            .Where(x =>
                x.Date.Contains(model.Search)
            ).GetPageAsync<SearchGradesResponse, Grades, GradesShortModel>(model, x => new GradesShortModel
            {
                Id =x.Id,
                SubjectId = x.SubjectId,
                Date = x.Date,
                Grade= x.Grade,
                StudentId = x.StudentId
            });
    }

    public async Task<GetGradesResponse> GetGradesAsync(GetGradesRequest request)
    {
        return await _db.Grades.GetPageAsync<GetGradesResponse, Grades, GradesShortModel>(request, grades =>
            new GradesShortModel
            {
                Id = grades.Id,
                SubjectId = grades.SubjectId,
                Date = grades.Date,
                Grade = grades.Grade,
                StudentId = grades.StudentId
                
            });
    }
    

    public async Task Update(long id, long subjectId,long studentId, long grade, string date)
    {
        var grades = await _db.Grades.FirstOrDefaultAsync(x => x.Id == id);
        if (grades is null)
            throw new TirException($"Grades Id = {id} is not found!", EnumErrorCode.EntityIsNotFound);

        if (!string.IsNullOrWhiteSpace(date))
            grades.Date = date;
        
        if (studentId > 0)
        {
            if (await _db.Parents.AllAsync(x => x.Id != studentId))
                throw new TirException($"StudentId {studentId} is not exists!", EnumErrorCode.EntityIsNotFound);
            grades.StudentId = studentId;
        }
        await _db.SaveChangesAsync();
    }

    public async Task Remove(long id)
    {
        if (await _db.Grades.AllAsync(x => x.Id != id))
            throw new TirException($"Grades id = {id} is not exists!",EnumErrorCode.EntityIsNotFound);

	
        _db.Grades.Remove(new Grades { Id = id });
        await _db.SaveChangesAsync();
    }
}