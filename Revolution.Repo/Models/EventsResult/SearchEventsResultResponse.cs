using PublishingHouse.Interfaces.Extensions.Pagination;

namespace Revolution.Repo.Models.EventsResult;

public class SearchEventsResultResponse : IPaginationResponse<EventsResultShortModel>
{

    public Page Page { get; set; } = new Page();
    
    public long Count { get; set; }
    
    public IReadOnlyCollection<EventsResultShortModel> Items { get; set; }
}