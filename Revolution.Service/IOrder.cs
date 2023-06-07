using Revolution.Service.Model;
using Revolution.Service.Model.User;

namespace Revolution.Service;

public interface IOrder
{
    Task<BaseResponse> AddOrder(RegisterRequest request);
}