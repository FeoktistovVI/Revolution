using PublishingHouse.Interfaces.Extensions.Pagination;

namespace Revolution.Repo.Models.EventsResult;

public class EventsResultGetModel : IPaginationRequest
{
    public Page Page { get; set; } = new Page();
    
    public string Search { get; set; } = string.Empty;
}