using Microsoft.EntityFrameworkCore;
using PublishingHouse.Interfaces.Extensions.Pagination;
using Revolution.Data;
using Revolution.Repo.Enums;
using Revolution.Repo.Interfaces;
using Revolution.Repo.Models;
using Revolution.Repo.Models.School;

namespace Revolution.Repo.Services;

public class SchoolService : ISchool
{
    private readonly AplicationContext _db;

    public SchoolService(AplicationContext db)
    {
        _db = db;
    }
    
    public async Task<School> Add(long id, string name, long areaId)
    {
        if (await _db.Schools.AllAsync(x => x.Name == name))
            throw new TirException($"School {name} already exists!", EnumErrorCode.EntityIsAlreadyExists);
        var school = new School
        {	Id = id,
            Name = name,
            AreaId = areaId
        };
        await _db.AddAsync(school);
        await _db.SaveChangesAsync();
		
        return school;
    }

    public async Task<SearchSchoolResponse> SearchSchool(SchoolGetModel model)
    {
        return await _db.Schools
            .Where(x =>
                x.Id.ToString().Contains(model.Search)
                || x.Name.Contains(model.Search)
            ).GetPageAsync<SearchSchoolResponse, School, SchoolShortModel>(model, x => new SchoolShortModel
            {
                Id =x.Id,
                Name = x.Name,
                AreaId = x.AreaId
            });
    }

    public async Task<GetSchoolResponse> GetSchoolAsync(GetSchoolRequest request)
    {
        return await _db.Schools.GetPageAsync<GetSchoolResponse, School, SchoolShortModel>(request, school =>
            new SchoolShortModel
            {
                Id = school.Id,
                Name = school.Name,
                AreaId = school.AreaId
            });
    }

    public async Task Update(long id, string name, long areaId)
    {
        var school = await _db.Schools.FirstOrDefaultAsync(x => x.Id == id);
        if (school is null)
            throw new TirException($" Id = {id} is not found!", EnumErrorCode.EntityIsNotFound);
        if (!string.IsNullOrWhiteSpace(name))
            school.Name = name;
        await _db.SaveChangesAsync();
    }
    
    public async Task DeleteSchoolAsync(long id)
    {
        if (await _db.Schools.AnyAsync(x => x.Id == id))
            throw new TirException("School is not found!", EnumErrorCode.EntityIsNotFound);

        _db.Schools.Remove(new School {Id = id});
        await _db.SaveChangesAsync();
    }
}