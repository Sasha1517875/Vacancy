using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vacancy.BL.Resumes.Entities
{
    public class UpdateResumeModel
    {
        public string Education { get; set; }
        public string Experience { get; set; }
        public int ResumeStatusId { get; set; }
        public string Description { get; set; }
        public List<int> SkillsIds { get; set; }
    }
}
