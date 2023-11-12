using System.ComponentModel.DataAnnotations.Schema;

namespace Vacancy.DataAccess.Entities
{
    [Table("user_types")]
    public class UserType : BaseEntity
    {
        public string Type { get; set; }
    }
}
