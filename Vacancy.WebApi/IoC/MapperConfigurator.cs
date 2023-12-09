using Vacancy.BL.Mapper;
using Vacancy.WebApi.Mapper;

namespace Vacancy.WebApi.IoC
{
    public class MapperConfigurator
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(config =>
            {
                config.AddProfile<AdminBLProfile>();
                config.AddProfile<AdminsServiceProfile>();
                config.AddProfile<ResumeBLProfile>();
                config.AddProfile<ResumesServiceProfile>();
                config.AddProfile<SkillBLProfile>();
                config.AddProfile<ResumeStatusBLProfile>();
            });
        }
    }
}
