using PublishingHouse.Interfaces.Extensions.Pagination;

namespace Revolution.Repo.Models.Subject;

public class SubjectGetModel : IPaginationRequest
{
    public string Search { get; set; } = string.Empty;
    public Page Page { get; set; }
}