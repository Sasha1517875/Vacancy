using AutoMapper;
using Vacancy.BL.Admins.Entities;
using Vacancy.BL.Resumes.Entities;
using Vacancy.WebApi.Controllers.Entities;

namespace Vacancy.WebApi.Mapper
{
    public class AdminsServiceProfile: Profile
    {
        public AdminsServiceProfile() 
        {
            CreateMap<AdminsFilter, AdminModelFilter>();
            CreateMap<CreateAdminRequest, CreateAdminModel>();
            CreateMap<UpdateAdminRequest, UpdateAdminModel>();
        }
    }
}
