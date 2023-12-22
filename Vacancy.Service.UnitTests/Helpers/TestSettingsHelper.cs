using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vacancy.WebApi.Settings;

namespace Vacancy.Service.UnitTests.Helpers
{
    public class TestSettingsHelper
    {
        public static VacancySettings GetSettings()
        {
            return VacancySettingsReader.Read(ConfigurationHelper.GetConfiguration());
        }
    }
}
