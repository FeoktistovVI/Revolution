using PublishingHouse.Interfaces.Extensions.Pagination;

namespace Revolution.Repo.Models.Area{

public class GetAreaRequest : IPaginationRequest
{
	public long? Id { get; set; } = null;

	public Page Page { get; set; } = new Page();
}
}