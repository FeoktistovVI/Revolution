using PublishingHouse.Interfaces.Extensions.Pagination;

namespace Revolution.Repo.Models.Parents;

public class SearchParentsResponse : IPaginationResponse<ParentsShortModel>
{
    public Page Page { get; set; }
    public long Count { get; set; }
    public IReadOnlyCollection<ParentsShortModel> Items { get; set; }
}