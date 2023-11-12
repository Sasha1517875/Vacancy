namespace Vacancy.WebApi.Settings
{
    public static class VacancySettingsReader
    {
        public static VacancySettings Read(IConfiguration configuration)
        {
            return new VacancySettings()
            {
                VacancyDbContextConnectionString = configuration.GetValue<string>("VacancyDbContext")
            };
        }
    }
}
