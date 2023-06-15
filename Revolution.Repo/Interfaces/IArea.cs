using Revolution.Data.Models;
using Revolution.Repo.Models.Area;

namespace Revolution.Repo.Interfaces;

public interface IArea
{
    Task<Area> Add(long id,string areaName);

    Task<SearchAreaResponse> SearchArea(AreaGetModel model);

    Task<GetAreaResponse> GetAreaAsync(GetAreaRequest request);

    Task Update(long id,string areaName);
    
    Task DeleteAreaAsync(long id);
}