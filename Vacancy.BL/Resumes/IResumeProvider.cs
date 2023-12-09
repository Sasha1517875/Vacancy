using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vacancy.BL.Admins.Entities;
using Vacancy.BL.Companies.Entities;
using Vacancy.BL.Resumes.Entities;

namespace Vacancy.BL.Resumes
{
    public interface IResumeProvider
    {
        IEnumerable<ResumeModel> GetResumes(ResumeModelFilter filter = null);
        ResumeModel GetResumeInfo(Guid id);
    }
}
