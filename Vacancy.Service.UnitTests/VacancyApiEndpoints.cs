using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vacancy.Service.UnitTests
{
    public class VacancyApiEndpoints
    {
        public const string AuthorizeUserEndpoint = "Auth/login";
        public const string RegisterUserEndpoint = "Auth/register";
        public const string GetAllResumesEndpoint = "Resume";
    }
}
