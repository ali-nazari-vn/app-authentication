using System.ComponentModel.DataAnnotations;

namespace Authentication.Core.DTOs.Security
{
    public class RegisterDTO
    {
        public int Id { get; set; }

        [MaxLength(20)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string UserName { get; set; }

        [MaxLength(100)]
        public string Password { get; set; }
    }
}
