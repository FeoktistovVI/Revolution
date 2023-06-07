using Revolution.Data.Enums;

namespace Revolution.Service.Model.User;

public class UserResponse
{
	public string Token { get; set; } = string.Empty;
	public string Fio { get; set; } = string.Empty;
	public EnumUserRole Role { get; set; }
	public long Id { get; set; }
}