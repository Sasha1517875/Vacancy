namespace Vacancy.BL.Resumes.Entities
{
    public class CreateResumeModel
    {
        public int UserId { get; set; }
        public string Education { get; set; }
        public string Experience { get; set; }
        public int ResumeStatusId { get; set; }
        public string Description { get; set; }
        public List<int> SkillsIds { get; set; }
    }
}
