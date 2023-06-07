using PublishingHouse.Interfaces.Extensions.Pagination;

namespace Revolution.Repo.Models.Parents{

public class GetParentsRequest : IPaginationRequest
{
	public long? Id { get; set; } = null;

	public Page Page { get; set; } = new Page();
}
}