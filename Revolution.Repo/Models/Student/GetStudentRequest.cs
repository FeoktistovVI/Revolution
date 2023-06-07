using PublishingHouse.Interfaces.Extensions.Pagination;

namespace Revolution.Repo.Models.Student{

public class GetStudentRequest : IPaginationRequest
{
	public long? Id { get; set; } = null;

	public Page Page { get; set; } = new Page();
}
}