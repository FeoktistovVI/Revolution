using System.ComponentModel.DataAnnotations;

namespace Revolution.Service.Model.User{

public class UserRequest
{
	/// <summary>
	/// Почта
	/// </summary>
	[Required]
	public string Email { get; set; } = null!;

	/// <summary>
	/// Пароль
	/// </summary>
	[Required]
	public string Password { get; set; } = null!;
}
}