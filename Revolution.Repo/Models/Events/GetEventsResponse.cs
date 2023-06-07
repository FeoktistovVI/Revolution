using PublishingHouse.Interfaces.Extensions.Pagination;


namespace Revolution.Repo.Models.Events
{

public class GetEventsResponse : IPaginationResponse<EventsShortModel>
{
	public Page Page { get; set; } = new Page();

	public long Count { get; set; }

	public IReadOnlyCollection<EventsShortModel> Items { get; set; }
}
}