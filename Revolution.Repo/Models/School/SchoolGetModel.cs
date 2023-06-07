using PublishingHouse.Interfaces.Extensions.Pagination;

namespace Revolution.Repo.Models.School;

public class SchoolGetModel : IPaginationRequest
{
    public string Search { get; set; } = string.Empty;
    public Page Page { get; set; } = new Page();
}