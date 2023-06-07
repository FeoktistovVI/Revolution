using PublishingHouse.Interfaces.Extensions.Pagination;

namespace Revolution.Repo.Models.Grades{

public class GetGradesRequest : IPaginationRequest
{
	public long? Id { get; set; } = null;

	public Page Page { get; set; } = new Page();
}
}