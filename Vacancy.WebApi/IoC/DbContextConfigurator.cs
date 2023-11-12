using Microsoft.EntityFrameworkCore;
using Vacancy.DataAccess;
using Vacancy.WebApi.Settings;

namespace Vacancy.WebApi.IoC
{
    public class DbContextConfigurator
    {
        public static void ConfigureService(IServiceCollection services, VacancySettings settings)
        {
            services.AddDbContextFactory<VacancyDbContext>(
                options => { options.UseSqlServer(settings.VacancyDbContextConnectionString); },
                ServiceLifetime.Scoped);
        }

        public static void ConfigureApplication(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<VacancyDbContext>>();
            using var context = contextFactory.CreateDbContext();
            context.Database.Migrate();
        }
    }
}
