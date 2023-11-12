using System.ComponentModel.DataAnnotations.Schema;

namespace Vacancy.DataAccess.Entities
{
    [Table("skills")]
    public class Skill : BaseEntity
    {
        public string Name { get; set; }
    }
}
