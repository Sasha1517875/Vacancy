using System.ComponentModel.DataAnnotations.Schema;

namespace Vacancy.DataAccess.Entities
{
    [Table("companies")]
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
