using PublishingHouse.Interfaces.Extensions.Pagination;

namespace Revolution.Repo.Models.Grades
{

public class GetGradesResponse : IPaginationResponse<GradesShortModel>
{
	public Page Page { get; set; } = new Page();

	public long Count { get; set; }

	public IReadOnlyCollection<GradesShortModel> Items { get; set; }
}
}