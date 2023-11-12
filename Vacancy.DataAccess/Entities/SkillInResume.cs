using System.ComponentModel.DataAnnotations.Schema;

namespace Vacancy.DataAccess.Entities
{
    [Table("skill_in_resumes")]
    public class SkillInResume : BaseEntity
    {
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
        public int ResumeId { get; set; }
        public Resume Resume { get; set; }
    }
}
