using Authentication.Core.DTOs.Security;

namespace Authentication.Core.Services.Interface.Security
{
    public interface IUserService
    {
        Task<LoginOutputDTO> LogIn(LoginDTO logInVM);
        Task Register(RegisterDTO registerDTO);
    }
}
