using AutoMapper;
using Vacancy.BL.Resumes.Entities;
using Vacancy.DataAccess.Entities;

namespace Vacancy.BL.Mapper
{
    public class ResumeBLProfile : Profile
    {
        public ResumeBLProfile()
        {
            CreateMap<Resume, ResumeModel>()
               .ForMember(x => x.Id, y => y.MapFrom(src => src.ExternalId))
               .ForMember(x => x.Skills, y => y.MapFrom(src => src.SkillsInResume.Select(s => s.Skill)))
               .ForMember(x=>x.ResumeStatus, y=>y.MapFrom(src=>src.ResumeStatus));

            CreateMap<CreateResumeModel, Resume>()
                .ForMember(x => x.Id, y => y.Ignore())
                .ForMember(x => x.ExternalId, y => y.Ignore())
                .ForMember(x => x.ModificationTime, y => y.Ignore())
                .ForMember(x => x.CreationTime, y => y.Ignore())
                .ForMember(x => x.SkillsInResume, y => y.Ignore())
                .ForMember(x => x.ResumeStatus, y => y.Ignore())
                .ForMember(x => x.User, y => y.Ignore());
        }
    }
}
