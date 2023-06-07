using PublishingHouse.Interfaces.Extensions.Pagination;

namespace Revolution.Repo.Models.Subject{

public class GetSubjectRequest : IPaginationRequest
{
	public long? Id { get; set; } = null;

	public Page Page { get; set; } = new Page();
}
}