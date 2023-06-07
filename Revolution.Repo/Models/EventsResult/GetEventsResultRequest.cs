using PublishingHouse.Interfaces.Extensions.Pagination;

namespace Revolution.Repo.Models.EventsResult{

public class GetEventsResultRequest : IPaginationRequest
{
	public long? Id { get; set; } = null;

	public Page Page { get; set; } = new Page();
}
}