using Revolution.Service.Model;
using Revolution.Service.Model.User;

namespace Revolution.Service
{

	public interface IUserService
	{
		Task<BaseResponse<UserResponse>> Login(UserRequest request);

		Task<BaseResponse> Register(RegisterRequest request);

		Task<BaseResponse<TokenResponse>> ActivateAccount(ActivateAccountRequest request);
	}
}