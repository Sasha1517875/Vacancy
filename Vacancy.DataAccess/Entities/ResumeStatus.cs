using System.ComponentModel.DataAnnotations.Schema;

namespace Vacancy.DataAccess.Entities
{
    [Table("resume_statuses")]
    public class ResumeStatus : BaseEntity
    {
        public string Status { get; set; }
    }
}
