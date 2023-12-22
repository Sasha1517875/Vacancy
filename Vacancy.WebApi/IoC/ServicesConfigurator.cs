using Microsoft.AspNetCore.Identity;
using Vacancy.BL.Admins;
using Vacancy.BL.Auth;
using Vacancy.BL.Resumes;
using Vacancy.BL.Skills;
using Vacancy.Repository;
using Vacancy.WebApi.Settings;
using UserEntity = Vacancy.DataAccess.Entities.User;

namespace Vacancy.WebApi.IoC
{
    public class ServicesConfigurator
    {
        public static void ConfigureService(IServiceCollection services, VacancySettings settings)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<IAdminManager, AdminManager>();
            services.AddScoped<IAdminProvider, AdminProvider>();

            services.AddScoped<IResumeManager, ResumeManager>();
            services.AddScoped<IResumeProvider, ResumeProvider>();

            services.AddScoped<ISkillManager, SkillManager>();
            services.AddScoped<ISkillProvider, SkillProvider>();

            services.AddScoped<IAuthProvider>(x =>
            new AuthProvider(x.GetRequiredService<SignInManager<UserEntity>>(),
                x.GetRequiredService<UserManager<UserEntity>>(),
                x.GetRequiredService<IHttpClientFactory>(),
                settings.IdentityServerUri,
                settings.ClientId,
                settings.ClientSecret));
        }
    }
}
