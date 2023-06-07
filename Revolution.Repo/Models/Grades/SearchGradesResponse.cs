using PublishingHouse.Interfaces.Extensions.Pagination;

namespace Revolution.Repo.Models.Grades;

public class SearchGradesResponse : IPaginationResponse<GradesShortModel>
{
    public Page Page { get; set; }
    public long Count { get; set; }
    public IReadOnlyCollection<GradesShortModel> Items { get; set; }
}