using Microsoft.EntityFrameworkCore;
using PublishingHouse.Interfaces.Extensions.Pagination;
using Revolution.Data;
using Revolution.Data.Models;
using Revolution.Repo.Enums;
using Revolution.Repo.Interfaces;
using Revolution.Repo.Models;
using Revolution.Repo.Models.Parents;

namespace Revolution.Repo.Services;

public class ParentsService : IParents
{
    private readonly AplicationContext _db;

    public ParentsService(AplicationContext db)
    {
        _db = db;
    }

    public async Task<ParentsShortModel> Add(long id, long studentId, string firstName, string lastName, string phone)
    {
        if (await _db.Parents.FirstOrDefaultAsync(x => x.Id != id)!=null)
            throw new TirException($"Parents {id} is not exists!", EnumErrorCode.EntityIsNotFound);
		
        var parent = new Parents
        {
            Id = id,
            StudentId = studentId,
            Phone = phone,
            FirstName = firstName,
            LastName = lastName
			
        };		
        await _db.AddAsync(parent);
        await _db.SaveChangesAsync();

        return new ParentsShortModel
        {
            Id = parent.Id,
            StudentId = parent.StudentId,
            Phone = parent.Phone,
            FirstName = parent.FirstName,
            LastName = parent.LastName
        };
    }
    

    public async Task<SearchParentsResponse> SearchParents(ParentsGetModel model)
    {
        return await _db.Parents
            .Where(x =>
                x.LastName.Contains(model.Search)
                || x.Phone.Contains(model.Search)
            ).GetPageAsync<SearchParentsResponse, Parents, ParentsShortModel>(model, x => new ParentsShortModel
            {
                Id =x.Id,
                FirstName =x.FirstName,
                LastName = x.LastName,
                Phone=x.Phone,
                StudentId = x.StudentId,
            });
    }

    public async Task<GetParentsResponse> GetParentsAsync(GetParentsRequest request)
    {
        return await _db.Parents.GetPageAsync<GetParentsResponse, Parents, ParentsShortModel>(request, parent =>
            new ParentsShortModel
            {
                Id = parent.Id,
                FirstName = parent.FirstName,
                LastName = parent.LastName,
                Phone = parent.Phone,
                StudentId  = parent.StudentId,
				
            });
    }

    public async Task Update(long id, long studentId, string firstName, string lastName, string phone)
    {
        var parent = await _db.Parents.FirstOrDefaultAsync(x => x.Id == id);
        if (parent is null)
            throw new TirException($"Parents Id = {id} is not found!", EnumErrorCode.EntityIsNotFound);

        if (!string.IsNullOrWhiteSpace(firstName))
            parent.FirstName = firstName;
        
        if (!string.IsNullOrWhiteSpace(lastName))
            parent.LastName = lastName;

        if (!string.IsNullOrWhiteSpace(phone))
            parent.Phone = phone;
        if (studentId > 0)
        {
            if (await _db.Parents.AllAsync(x => x.Id != studentId))
                throw new TirException($"StudentId {studentId} is not exists!", EnumErrorCode.EntityIsNotFound);
            parent.StudentId = studentId;
        }
        await _db.SaveChangesAsync();
    }

    public async Task Remove(long id)
    {
        if (await _db.Parents.AllAsync(x => x.Id != id))
            throw new TirException($"Parents id = {id} is not exists!",EnumErrorCode.EntityIsNotFound);

	
        _db.Parents.Remove(new Parents { Id = id });
        await _db.SaveChangesAsync();
    }
}