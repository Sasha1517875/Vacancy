using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vacancy.DataAccess.Entities
{
    [Table("users")]
    public class User : IdentityUser<int>, IBaseEntity
    {
        [Key]
        public int Id { get; set; }
        public Guid ExternalId { get; set; }
        public DateTime ModificationTime { get; set; }
        public DateTime CreationTime { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string SecretHash { get; set; }
        public int UserTypeId { get; set; }
        public UserType UserType { get; set; }
        public virtual ICollection<Resume> Resumes { get; set; }
    }

    public class UserRoleEntity : IdentityRole<int>
    {
    }
}
