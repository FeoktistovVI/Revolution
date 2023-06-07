using Revolution.Data;
using Revolution.Repo.Models.School;

namespace Revolution.Repo.Interfaces;

public interface ISchool
{
    Task<School> Add(long id,string name, long areaId);

    Task<SearchSchoolResponse> SearchSchool(SchoolGetModel model);

    Task<GetSchoolResponse> GetSchoolAsync(GetSchoolRequest request);
    
    Task Update(long id,string name, long areaId);
    
    Task DeleteSchoolAsync(long id);
}