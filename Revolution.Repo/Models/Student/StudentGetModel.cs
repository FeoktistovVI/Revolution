using PublishingHouse.Interfaces.Extensions.Pagination;

namespace Revolution.Repo.Models.Student;

public class StudentGetModel : IPaginationRequest
{
    public string Search { get; set; } = string.Empty;
    public Page Page { get; set; } = new Page();
}