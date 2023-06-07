using PublishingHouse.Interfaces.Extensions.Pagination;

namespace Revolution.Repo.Models.Events{

public class GetEventsRequest : IPaginationRequest
{
	public long? Id { get; set; } = null;

	public Page Page { get; set; } = new Page();
}
}