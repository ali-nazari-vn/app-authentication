using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Authentication.Data.Entities
{
    [Table("Users", Schema = "Security")]
    public class User : BaseEntity
    {
        [MaxLength(20)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string UserName { get; set; }

        [MaxLength(100)]
        public string Password { get; set; }
    }
}
