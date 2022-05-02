using DonutWorld.Api.Models.Create;
using DonutWorld.Api.Models.Update;

namespace DonutWorld.Api.Services.Abstractions
{
    public interface IUserService
    {
        Task<Models.UserModel> FindByIdAsync(Guid id);
        Task<List<Models.UserModel>> GetAllAsync();
        Task<Guid> CreateAsync(CreateUserModel createUserModel);
        Task<Guid> DeleteAsync(Guid id);
        Task<Guid> UpdateAsync(UpdateUserModel updateUserModel);
    }
}
