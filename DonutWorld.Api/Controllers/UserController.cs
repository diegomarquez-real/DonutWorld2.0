using DonutWorld.Api.Models;
using DonutWorld.Api.Models.Create;
using DonutWorld.Api.Models.Update;
using DonutWorld.Api.Services.Abstractions;
using FaultlessExecution.Abstractions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DonutWorld.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;
        private readonly IFaultlessExecutionService _faultlessExecutionService;

        public UserController(IUserService userService,
                              ILogger<UserController> logger,
                              IFaultlessExecutionService faultlessExecutionService)
        {
            _userService = userService;
            _logger = logger;
            _faultlessExecutionService = faultlessExecutionService;
        }

        [HttpPost(Name = "CreateUser")]
        public async Task<Guid> CreateUser([FromBody]CreateUserModel createUserModel)
        {
            var result = await _faultlessExecutionService.TryExecuteAsync(async () => await _userService.CreateAsync(createUserModel)); 

            return result.ReturnValue;
        }

        [HttpGet("{id}", Name = "GetUser")]
        public async Task<UserModel> GetUser([FromRoute] Guid id)
        {
            var result = await _faultlessExecutionService.TryExecuteAsync(async () => await _userService.FindByIdAsync(id));

            return result.ReturnValue;
        }

        [HttpGet("GetAll", Name = "GetAllUsers")]
        public async Task<List<UserModel>> GetUsers()
        {
            var result = await _faultlessExecutionService.TryExecuteAsync(async () => await _userService.GetAllAsync());

            return result.ReturnValue;
        }

        [HttpPut(Name = "UpdateUser")]
        public async Task<Guid> UpdateUser([FromBody] UpdateUserModel updateUserModel)
        {
            var result = await _faultlessExecutionService.TryExecuteAsync(async () => await _userService.UpdateAsync(updateUserModel));

            return result.ReturnValue;
        }

        [HttpDelete("{id}", Name = "DeleteUser")]
        public async Task<Guid> DeleteUser([FromRoute] Guid userId)
        {
            var result = await _faultlessExecutionService.TryExecuteAsync(async () => await _userService.DeleteAsync(userId));

            return result.ReturnValue;
        }
    }
}
