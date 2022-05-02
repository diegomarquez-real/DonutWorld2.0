using AutoMapper;
using DonutWorld.Api.Models;
using DonutWorld.Api.Models.Create;
using DonutWorld.Api.Models.Update;
using DonutWorld.Data.Abstractions.Repositories;
using DonutWorld.Data.Models;

namespace DonutWorld.Api.Services
{
    public class UserService : Abstractions.IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, 
                           IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Task<Guid> DeleteAsync(Guid id)
        {
            return _userRepository.DeleteAsync(id);
        }

        public async Task<UserModel> FindByIdAsync(Guid id)
        {
            var user = await _userRepository.FindByIdAsync(id);

            return _mapper.Map<UserModel>(user);
        }

        public async Task<List<UserModel>> GetAllAsync()
        {
           var result = await _userRepository.GetAllAsync();

            var users = _mapper.Map<IEnumerable<User>, List<UserModel>>(result);

           return users;
        }

        public async Task<Guid> CreateAsync(CreateUserModel createUserModel)
        {
            var model = _mapper.Map<User>(createUserModel);

            model.UserId = Guid.NewGuid();

            model.CreatedOn = DateTime.Now;

            var createdUserId = await _userRepository.CreateAsync(model);

            return createdUserId;
        }

        public async Task<Guid> UpdateAsync(UpdateUserModel updateUserModel)
        {
            var model = _mapper.Map<User>(updateUserModel);

            model.UpdatedOn = DateTime.Now;

            var updatedUserId = await _userRepository.UpdateAsync(model);

            return updatedUserId;
        }
    }
}
