using PublishingHouse.Interfaces.Extensions.Pagination;

namespace Revolution.Repo.Models.School{

public class GetSchoolRequest : IPaginationRequest
{
	public long? Id { get; set; } = null;

	public Page Page { get; set; } = new Page();
}
}