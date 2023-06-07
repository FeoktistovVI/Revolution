using PublishingHouse.Interfaces.Extensions.Pagination;

namespace Revolution.Repo.Models.School
{

public class GetSchoolResponse : IPaginationResponse<SchoolShortModel>
{
	public Page Page { get; set; } = new Page();

	public long Count { get; set; }

	public IReadOnlyCollection<SchoolShortModel> Items { get; set; }
}
}