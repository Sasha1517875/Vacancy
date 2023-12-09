using Vacancy.BL.Admins.Entities;
using Vacancy.BL.Companies.Entities;
using Vacancy.BL.Resumes.Entities;

namespace Vacancy.BL.Resumes
{
    public interface IResumeManager
    {
        ResumeModel CreateResume(CreateResumeModel model);
        void DeleteResume(Guid id);
        ResumeModel UpdateResume(Guid id, UpdateResumeModel model);
    }
}
