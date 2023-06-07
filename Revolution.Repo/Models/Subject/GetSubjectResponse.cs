using PublishingHouse.Interfaces.Extensions.Pagination;


namespace Revolution.Repo.Models.Subject
{

public class GetSubjectResponse : IPaginationResponse<SubjectShortModel>
{
	public Page Page { get; set; } = new Page();

	public long Count { get; set; }

	public IReadOnlyCollection<SubjectShortModel> Items { get; set; }
}
}