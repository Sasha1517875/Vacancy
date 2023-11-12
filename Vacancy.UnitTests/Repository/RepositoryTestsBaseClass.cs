using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vacancy.DataAccess;
using Vacancy.WebApi.Settings;

namespace Vacancy.UnitTests.Repository
{

    public class RepositoryTestsBaseClass
    {
        public RepositoryTestsBaseClass()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile("appsettings.Test.json", optional: true)
                .Build();

            Settings = VacancySettingsReader.Read(configuration);
            ServiceProvider = ConfigureServiceProvider();

            DbContextFactory = ServiceProvider.GetRequiredService<IDbContextFactory<VacancyDbContext>>();
        }

        private IServiceProvider ConfigureServiceProvider()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContextFactory<VacancyDbContext>(
                options => { options.UseSqlServer(Settings.VacancyDbContextConnectionString); },
                ServiceLifetime.Scoped);
            return serviceCollection.BuildServiceProvider();
        }

        protected readonly VacancySettings Settings;
        protected readonly IDbContextFactory<VacancyDbContext> DbContextFactory;
        protected readonly IServiceProvider ServiceProvider;
    }
}