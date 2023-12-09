using AutoMapper;
using Vacancy.BL.Resumes.Entities;
using Vacancy.WebApi.Controllers.Entities;

namespace Vacancy.WebApi.Mapper
{
    public class ResumesServiceProfile: Profile
    {
        public ResumesServiceProfile()
        {
            CreateMap<ResumesFilter, ResumeModelFilter>();
            CreateMap<CreateResumeRequest, CreateResumeModel>();
            CreateMap<UpdateResumeRequest, UpdateResumeModel>();
        }
    }
}
