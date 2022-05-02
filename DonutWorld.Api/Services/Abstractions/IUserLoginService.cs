using DonutWorld.Api.Models;

namespace DonutWorld.Api.Services.Abstractions
{
    public interface IUserLoginService
    {
        Task<UserModel> LoginUser(UserLoginModel userLoginModel);
    }
}
