using System.ComponentModel.DataAnnotations.Schema;

namespace Vacancy.DataAccess.Entities
{
    [Table("users")]
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string SecretHash { get; set; }
        public int UserTypeId { get; set; }
        public UserType UserType { get; set; }
        public virtual ICollection<Resume> Resumes { get; set;}
    }
}
