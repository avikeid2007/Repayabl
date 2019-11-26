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
                 cfg.CreateMap<Property, Models.DTOs.Property>();
                 cfg.CreateMap<Models.DTOs.Property, Property>();
                 cfg.CreateMap<Room, Models.DTOs.Room>();
                 cfg.CreateMap<Models.DTOs.Room, Room>();
                 cfg.CreateMap<Tenant, Models.DTOs.Tenant>();
                 cfg.CreateMap<Models.DTOs.Tenant, Tenant>();
             });
            return new Mapper(configuration);
        }
    }
}
