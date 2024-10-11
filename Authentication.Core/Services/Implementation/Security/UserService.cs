using Authentication.Core.DTOs.Security;
using Authentication.Core.Services.Interface.Security;
using Authentication.Core.Utilities.Security;
using Authentication.Data.Context;
using Authentication.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Core.Services.Implementation.Security
{
    public class UserService : IUserService
    {
        #region ctor
        private readonly AuthenticationContext authenticationContext;

        public UserService(AuthenticationContext authenticationContext)
        {
            this.authenticationContext = authenticationContext;
        }
        #endregion

        #region LogIn
        public async Task<LoginOutputDTO> LogIn(LoginDTO logInVM)
        {
            var user = await authenticationContext.Users
             .FirstOrDefaultAsync(q => q.UserName == logInVM.UserName.Trim());

            if (user == null) throw new Exception("User Not Found");

            var hashPassword = PasswordHelper.HashSHA256(logInVM.Password.Trim());

            if (user.Password != hashPassword) throw new Exception("User Not Found");

            return new LoginOutputDTO(user.Id, user.Name);
        }
        #endregion

        #region Register
        public async Task Register(RegisterDTO registerDTO)
        {
            var hashPassword = PasswordHelper.HashSHA256(registerDTO.Password.Trim());

            var user = new User
            {
                Name = registerDTO.Name,
                Password = hashPassword,
                UserName = registerDTO.UserName,
            };

            await authenticationContext.Users.AddAsync(user);
            await authenticationContext.SaveChangesAsync();
        }
        #endregion
    }
}
