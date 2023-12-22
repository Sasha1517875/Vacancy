namespace Vacancy.WebApi.Settings
{
    public class VacancySettings
    {
        public Uri ServiceUri { get; set; }
        public string VacancyDbContextConnectionString { get; set; }
        public string IdentityServerUri { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
