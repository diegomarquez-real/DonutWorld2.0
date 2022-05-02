using DonutWorld.Api.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DonutWorld.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserLoginController :  ControllerBase
    {
        private readonly IUserLoginService _userLoginService;
        private readonly IConfiguration _configuration;
        private readonly ILogger<UserLoginController> _logger;

        public UserLoginController(IUserLoginService userLoginService,
                                   IConfiguration configuration,
                                   ILogger<UserLoginController> logger)
        {
            _userLoginService = userLoginService;
            _configuration = configuration;
            _logger = logger;
        }

        [HttpPost(Name = "Login")]
        public async Task<IResult> LoginAsync(Models.UserLoginModel userLoginModel)
        {
            if (!String.IsNullOrEmpty(userLoginModel.Username) && !String.IsNullOrEmpty(userLoginModel.Password))
            {
                var loggedInUser = await _userLoginService.LoginUser(userLoginModel);

                if (loggedInUser == null)
                {
                    return Results.NotFound("User Not Found");
                }

                var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, loggedInUser.Username),
                    new Claim(ClaimTypes.Email, loggedInUser.EmailAddress),
                };

                var token = new JwtSecurityToken
                (
                    issuer: _configuration.GetSection("Jwt:Issuer").Value,
                    audience: _configuration.GetSection("Jwt:Audience").Value,
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(15),
                    notBefore: DateTime.UtcNow,
                    signingCredentials: new SigningCredentials(
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:Key").Value)),
                                                                SecurityAlgorithms.HmacSha256)
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                return Results.Ok(tokenString);
            }
            else
            {
                return Results.NotFound();
            }
        }
    }
}
