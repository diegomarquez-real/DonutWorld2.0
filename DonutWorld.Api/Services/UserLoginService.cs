using AutoMapper;
using DonutWorld.Api.Models;
using DonutWorld.Data.Abstractions.Repositories;

namespace DonutWorld.Api.Services
{
    public class UserLoginService : Abstractions.IUserLoginService
    {
        private readonly IUserLoginRepository _userLoginRepository;
        private readonly IMapper _mapper;

        public UserLoginService(Data.Abstractions.Repositories.IUserLoginRepository userLoginRepository, IMapper mapper)
        {
            _userLoginRepository = userLoginRepository;
            _mapper = mapper;
        }

        public async Task<UserModel> LoginUser(UserLoginModel userLoginModel)
        {
            var user = await _userLoginRepository.LoginUser(userLoginModel);

            return _mapper.Map<UserModel>(user);
        }
    }
}
