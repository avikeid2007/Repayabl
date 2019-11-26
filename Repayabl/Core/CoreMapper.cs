using AutoMapper;
using Repayabl.Models;

namespace Repayabl.Core
{
    public static class CoreMapper
    {
        public static IMapper GetMapper(string baseUrl)
        {
            IConfigurationProvider configuration = new MapperConfiguration(cfg =>
             {
                 cfg.CreateMap<User, Models.DTOs.User>();
                 cfg.CreateMap<Models.DTOs.User, User>();
             });
            return new Mapper(configuration);
        }
    }
}
