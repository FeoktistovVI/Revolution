using PublishingHouse.Interfaces.Extensions.Pagination;

namespace Revolution.Repo.Models.Subject;

public class SearchSubjectResponse : IPaginationResponse<SubjectShortModel>
{
    public Page Page { get; set; }
    public long Count { get; set; }
    public IReadOnlyCollection<SubjectShortModel> Items { get; set; }
}