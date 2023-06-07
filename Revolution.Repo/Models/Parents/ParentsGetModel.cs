using PublishingHouse.Interfaces.Extensions.Pagination;

namespace Revolution.Repo.Models.Parents;

public class ParentsGetModel : IPaginationRequest
{
    public string Search { get; set; } = string.Empty;
    public Page Page { get; set; } = new Page();
}