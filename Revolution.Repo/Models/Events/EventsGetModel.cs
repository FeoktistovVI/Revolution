using PublishingHouse.Interfaces.Extensions.Pagination;

namespace Revolution.Repo.Models.Events;

public class EventsGetModel : IPaginationRequest
{
    public Page Page { get; set; } = new Page();
    
    public string Search { get; set; } = string.Empty;
}