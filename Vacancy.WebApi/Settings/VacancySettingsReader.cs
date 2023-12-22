namespace Vacancy.WebApi.Settings
{
    public static class VacancySettingsReader
    {
        public static VacancySettings Read(IConfiguration configuration)
        {
            return new VacancySettings()
            {
                ServiceUri = configuration.GetValue<Uri>("Uri"),
                VacancyDbContextConnectionString = configuration.GetValue<string>("VacancyDbContext"),
                IdentityServerUri = configuration.GetValue<string>("IdentityServerSettings:Uri"),
                ClientId = configuration.GetValue<string>("IdentityServerSettings:ClientId"),
                ClientSecret = configuration.GetValue<string>("IdentityServerSettings:ClientSecret"),
            };
        }
    }
}
