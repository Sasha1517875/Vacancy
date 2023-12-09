using Vacancy.BL.Admins;
using Vacancy.BL.Resumes;
using Vacancy.BL.Skills;
using Vacancy.Repository;

namespace Vacancy.WebApi.IoC
{
    public class ServicesConfigurator
    {
        public static void ConfigureService(IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<IAdminManager, AdminManager>();
            services.AddScoped<IAdminProvider, AdminProvider>();

            services.AddScoped<IResumeManager, ResumeManager>();
            services.AddScoped<IResumeProvider, ResumeProvider>();

            services.AddScoped<ISkillManager, SkillManager>();
            services.AddScoped<ISkillProvider, SkillProvider>();
        }
    }
}
