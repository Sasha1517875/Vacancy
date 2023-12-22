using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Moq;
using Vacancy.DataAccess.Entities;
using Vacancy.Repository;
using Vacancy.Service.UnitTests.Helpers;

namespace Vacancy.Service.UnitTests
{
    public class VacancyServiceTestsBaseClass
    {
        public VacancyServiceTestsBaseClass()
        {
            var settings = TestSettingsHelper.GetSettings();

            _testServer = new TestWebApplicationFactory(services =>
            {
                services.Replace(ServiceDescriptor.Scoped(_ =>
                {
                    var httpClientFactoryMock = new Mock<IHttpClientFactory>();
                    httpClientFactoryMock.Setup(x => x.CreateClient(It.IsAny<string>()))
                        .Returns(TestHttpClient);
                    return httpClientFactoryMock.Object;
                }));
                services.PostConfigureAll<JwtBearerOptions>(options =>
                {
                    options.ConfigurationManager = new ConfigurationManager<OpenIdConnectConfiguration>(
                        $"{settings.IdentityServerUri}/.well-known/openid-configuration",
                        new OpenIdConnectConfigurationRetriever(),
                        new HttpDocumentRetriever(TestHttpClient) //important
                        {
                            RequireHttps = false,
                            SendAdditionalHeaderData = true
                        });
                });
            });
        }

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            using var scope = GetService<IServiceScopeFactory>().CreateScope();
            var resumeRepository = scope.ServiceProvider.GetRequiredService<IRepository<Resume>>();
            var statusRepository = scope.ServiceProvider.GetRequiredService<IRepository<ResumeStatus>>();
            var userRepository = scope.ServiceProvider.GetRequiredService<IRepository<User>>();
            var userTypeRepository = scope.ServiceProvider.GetRequiredService<IRepository<UserType>>();
            var status = statusRepository.Save(new ResumeStatus() { Status = "Test status" });
            var type = userTypeRepository.Save(new UserType() { Type = "test type" });

            var user = userRepository.Save(new User() { Email = "test", SecretHash = "test hash", Name = "testttt", UserTypeId = type.Id });

            var resume = resumeRepository.Save(new Resume()
            {
                Education = "Test education",
                Description = "Test description",
                Experience = "Test experience",
                ResumeStatusId = status.Id,
                UserId = user.Id
            });
            TestResumeId = resume.Id;
            TestTypeId = type.Id;
        }

        public T? GetService<T>()
        {
            return _testServer.Services.GetRequiredService<T>();
        }

        private readonly WebApplicationFactory<Program> _testServer;
        protected int TestResumeId;
        protected int TestTypeId;
        protected HttpClient TestHttpClient => _testServer.CreateClient();
    }
}
