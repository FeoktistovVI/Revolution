using PublishingHouse.Interfaces.Extensions.Pagination;

namespace Revolution.Repo.Models.Area;

public class AreaGetModel : IPaginationRequest
{
    public Page Page { get; set; } = new Page();
    
    public string Search { get; set; } = string.Empty;
}