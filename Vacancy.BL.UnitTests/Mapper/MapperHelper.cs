using AutoMapper;
using Vacancy.WebApi.Mapper;

namespace Vacancy.BL.UnitTests.Mapper
{
    public static class MapperHelper
    {
        static MapperHelper()
        {
            var config = new MapperConfiguration(x => 
            { 
                x.AddProfile(typeof(AdminsServiceProfile));
                x.AddProfile(typeof(ResumesServiceProfile));
            });
            Mapper = new AutoMapper.Mapper(config);
        }

        public static IMapper Mapper { get; }
    }
}
