using Authentication.Core.DTOs.Security;
using Authentication.Core.Services.Interface.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Authentication.Controllers.Security
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region ctor
        private readonly IUserService userService;
        private readonly IConfiguration iConfig;

        public UserController(IUserService userService, IConfiguration iConfig)
        {
            this.userService = userService;
            this.iConfig = iConfig;
        }
        #endregion

        [HttpPost]
        public async Task<IActionResult> Post(RegisterDTO registerDTO)
        {
            await this.userService.Register(registerDTO);
            return Ok();
        }

        [HttpPost]
        [Route("LogIn")]
        public async Task<IActionResult> LogIn(LoginDTO loginDTO)
        {
            var user = await this.userService.LogIn(loginDTO);
            return Ok(CreateJWTToken(user));
        }

        #region Create JWT Token
        private string CreateJWTToken(LoginOutputDTO loginOutputDTO)
        {
            var tokenKey = iConfig.GetValue<string>("TokenKey");

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(tokenKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("userId", loginOutputDTO.UserId.ToString()),
                    new Claim("name", loginOutputDTO.Name),
                }),

                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        #endregion
    }
}
