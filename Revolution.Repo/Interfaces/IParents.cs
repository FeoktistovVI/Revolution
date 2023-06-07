using Revolution.Repo.Models.Parents;

namespace Revolution.Repo.Interfaces;

public interface IParents
{
    Task<ParentsShortModel> Add(long id, long studentId, string firstName, string lastName, string phone);

    Task<SearchParentsResponse> SearchParents(ParentsGetModel model);
    
    Task<GetParentsResponse> GetParentsAsync(GetParentsRequest request);

    Task Update(long id, long studentId, string firstName, string lastName, string phone);
    
    Task Remove(long id);
}