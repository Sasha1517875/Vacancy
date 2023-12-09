using AutoMapper;
using Vacancy.BL.Admins.Entities;
using Vacancy.DataAccess.Entities;

namespace Vacancy.BL.Mapper
{
    public class AdminBLProfile : Profile
    {
        public AdminBLProfile()
        {
            CreateMap<Admin, AdminModel>()
                .ForMember(x => x.Id, y => y.MapFrom(src => src.ExternalId));            

            CreateMap<CreateAdminModel, Admin>()
                .ForMember(x => x.Id, y => y.Ignore())
                .ForMember(x => x.ExternalId, y => y.Ignore())
                .ForMember(x => x.ModificationTime, y => y.Ignore())
                .ForMember(x => x.CreationTime, y => y.Ignore());
        }
    }
}
