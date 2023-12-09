using AutoMapper;
using Vacancy.BL.Skills.Entities;
using Vacancy.DataAccess.Entities;

namespace Vacancy.BL.Mapper
{
    public class SkillBLProfile : Profile
    {
        public SkillBLProfile()
        {
            CreateMap<Skill, SkillModel>()
                .ForMember(x => x.Id, y => y.MapFrom(src => src.ExternalId));

            CreateMap<CreateSkillModel, Skill>()
                .ForMember(x => x.Id, y => y.Ignore())
                .ForMember(x => x.ExternalId, y => y.Ignore())
                .ForMember(x => x.ModificationTime, y => y.Ignore())
                .ForMember(x => x.CreationTime, y => y.Ignore())
                .ForMember(x => x.SkillInResumes, y => y.Ignore())
                .ForMember(x => x.SkillInVacancies, y => y.Ignore());
        }
    }
}
