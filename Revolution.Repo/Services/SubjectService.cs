using Microsoft.EntityFrameworkCore;
using PublishingHouse.Interfaces.Extensions.Pagination;
using Revolution.Data;
using Revolution.Repo.Enums;
using Revolution.Repo.Interfaces;
using Revolution.Repo.Models;
using Revolution.Repo.Models.Subject;

namespace Revolution.Repo.Services;

public class SubjectService : ISubject
{
    private readonly AplicationContext _db;

    public SubjectService(AplicationContext db)
    {
        _db = db;
    }
    
    public async Task<Subject> Add(long id, string name)
    {
        if (await _db.Subjects.AllAsync(x => x.Name == name))
            throw new TirException($"Subject {name} already exists!", EnumErrorCode.EntityIsAlreadyExists);
        var subject = new Subject 
        {	Id = id,
            Name = name,
        };
        await _db.AddAsync(subject);
        await _db.SaveChangesAsync();
		
        return subject;
    }

    public async Task<SearchSubjectResponse> SearchSubject(SubjectGetModel model)
    {
          return await _db.Subjects
                			.Where(x =>
                				x.Name.Contains(model.Search)
                				|| (x.Id.ToString()).Contains(model.Search)
                				).GetPageAsync<SearchSubjectResponse, Subject, SubjectShortModel>(model, x => new SubjectShortModel
                			{
                				Id =x.Id,
                				Name = x.Name
                            });
    }

    public async Task<GetSubjectResponse> GetSubjectAsync(GetSubjectRequest request)
    {
        return await _db.Subjects.GetPageAsync<GetSubjectResponse, Subject, SubjectShortModel>(request, subject =>
            new SubjectShortModel
            {
                Id =subject.Id,
                Name = subject.Name
            });
    }
    
    public async Task Update(long id, string name)
    {
        var subject = await _db.Subjects.FirstOrDefaultAsync(x => x.Id == id);
        if (subject is null)
            throw new TirException($" Id = {id} is not found!", EnumErrorCode.EntityIsNotFound);
        if (!string.IsNullOrWhiteSpace(name))
            subject.Name = name;
        await _db.SaveChangesAsync();
    }

    public async Task DeleteSubjectAsync(long id)
    {
        if (await _db.Subjects.AnyAsync(x => x.Id == id))
            throw new TirException("Subject is not found!", EnumErrorCode.EntityIsNotFound);

        _db.Subjects.Remove(new Subject {Id = id});
        await _db.SaveChangesAsync();
    }

}