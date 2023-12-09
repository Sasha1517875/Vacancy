using Vacancy.BL.Resumes.Entities;

namespace Vacancy.WebApi.Controllers.Entities
{
    public class ResumesListResponse
    {
        public List<ResumeModel> Resumes { get; set; }
    }
}
