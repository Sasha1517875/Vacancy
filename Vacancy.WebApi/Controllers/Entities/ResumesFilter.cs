namespace Vacancy.WebApi.Controllers.Entities
{
    public class ResumesFilter
    {
        public int UserId { get; set; }
        public string Education { get; set; }
        public string Experience { get; set; }
        public int ResumeStatusId { get; set; }
        public List<int> RequiredSkillsIds { get; set; }
    }
}
