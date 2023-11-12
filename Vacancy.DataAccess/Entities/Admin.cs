using System.ComponentModel.DataAnnotations.Schema;

namespace Vacancy.DataAccess.Entities
{
    [Table("admins")]
    public class Admin : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string SecretHash { get; set; }
    }
}
