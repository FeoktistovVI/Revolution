using PublishingHouse.Interfaces.Extensions.Pagination;

namespace Revolution.Repo.Models.Grades;

public class GradesGetModel : IPaginationRequest
{
    public string Search { get; set; } = string.Empty;
    public Page Page { get; set; } = new Page();
    
}