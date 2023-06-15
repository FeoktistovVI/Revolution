using Microsoft.EntityFrameworkCore;
using PublishingHouse.Interfaces.Extensions.Pagination;
using Revolution.Data;
using Revolution.Data.Models;
using Revolution.Repo.Enums;
using Revolution.Repo.Interfaces;
using Revolution.Repo.Models;
using Revolution.Repo.Models.Area;

namespace Revolution.Repo.Services;

public class AreaService : IArea
{
    
    private readonly AplicationContext _db;

    public AreaService(AplicationContext db)
    {
        _db = db;
    }
    
    public async Task<Area> Add(long id, string areaName)
    {
        if (await _db.Areas.FirstOrDefaultAsync(x => x.AreaName == areaName) != null)
            throw new TirException($"Area {areaName} already exists!", EnumErrorCode.EntityIsAlreadyExists); 
        
        var area = new Area
        {	
            Id = id,
            AreaName = areaName,
        };
        await _db.AddAsync(area);
        await _db.SaveChangesAsync();
		
        return area;
    }

    public async Task<SearchAreaResponse> SearchArea(AreaGetModel model)
    {
        return await _db.Areas
        			.Where(x =>
        				x.AreaName.Contains(model.Search)
        				|| (x.Id.ToString()).Contains(model.Search)
        				).GetPageAsync<SearchAreaResponse, Area, AreaShortModel>(model, x => new AreaShortModel
        			{
        				/*Id =x.Id,*/
        				AreaName = x.AreaName
                    });
    }

    public async Task<GetAreaResponse> GetAreaAsync(GetAreaRequest request)
    {
        return await _db.Areas.GetPageAsync<GetAreaResponse, Area, AreaShortModel>(request, area =>
        			new AreaShortModel
        			{
                        /*Id =area.Id,*/
        				AreaName = area.AreaName,
                    });
    }
    
    
    public async Task Update(long id, string areaName)
    {
        var area = await _db.Areas.FirstOrDefaultAsync(x => x.Id == id);
        if (area is null)
            throw new TirException($" Id = {id} is not found!", EnumErrorCode.EntityIsNotFound);
        if (!string.IsNullOrWhiteSpace(areaName))
            area.AreaName = areaName;
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAreaAsync(long id)
    {
        if (await _db.Areas.AnyAsync(x => x.Id == id))
            throw new TirException("Area is not found!", EnumErrorCode.EntityIsNotFound);

        _db.Areas.Remove(new Area {Id = id});
        await _db.SaveChangesAsync();
    }
}