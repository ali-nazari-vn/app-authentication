using System.ComponentModel.DataAnnotations;

namespace Authentication.Core.DTOs.Security
{
    public class LoginDTO
    {
        [MaxLength(100)]
        public string UserName { get; set; }

        [MaxLength(100)]
        public string Password { get; set; }
    }

    public class LoginOutputDTO
    {
        public LoginOutputDTO(int userId, string name)
        {
            this.UserId = userId;
            this.Name = name;
        }

        public int UserId { get; set; }
        public string Name { get; set; }
    }
}
