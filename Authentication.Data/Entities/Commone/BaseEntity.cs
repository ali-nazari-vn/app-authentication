using System.ComponentModel.DataAnnotations;

namespace Authentication.Data.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
