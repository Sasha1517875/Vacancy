using System.ComponentModel.DataAnnotations.Schema;

namespace Vacancy.DataAccess.Entities
{
    [Table("resumes")]
    public class Resume : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public string Education { get; set; }
        public string Experience { get; set; }
        public int ResumeStatusId { get; set; }
        public ResumeStatus ResumeStatus { get; set; }
        public string Description { get; set; }
        public virtual ICollection<SkillInResume> SkillsInResume { get; set; }
    }
}
