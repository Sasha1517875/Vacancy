using Vacancy.BL.Skills.Entities;

namespace Vacancy.BL.Resumes.Entities
{
    public class ResumeModel
    {
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public string Education { get; set; }
        public string Experience { get; set; }
        public ResumeStatusEnum ResumeStatus { get; set; }
        public string Description { get; set; }
        public List<SkillModel> Skills { get; set; }
    }
}
