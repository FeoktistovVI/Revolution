using PublishingHouse.Interfaces.Extensions.Pagination;

namespace Revolution.Repo.Models.School;

public class SearchSchoolResponse : IPaginationResponse<SchoolShortModel>
{
    public Page Page { get; set; }
    public long Count { get; set; }
    public IReadOnlyCollection<SchoolShortModel> Items { get; set; }
}