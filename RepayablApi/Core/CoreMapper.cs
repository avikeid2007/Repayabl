using AutoMapper;
using RepayablApi.Models;

namespace RepayablApi.Core
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
                 cfg.CreateMap<FamilyDetail, Models.DTOs.FamilyDetail>();
                 cfg.CreateMap<Models.DTOs.FamilyDetail, FamilyDetail>();
                 cfg.CreateMap<TenantDocument, Models.DTOs.TenantDocument>();
                 cfg.CreateMap<Models.DTOs.TenantDocument, TenantDocument>();
                 cfg.CreateMap<TenantOutstanding, Models.DTOs.TenantOutstanding>();
                 cfg.CreateMap<Models.DTOs.TenantOutstanding, TenantOutstanding>();
             });
            return new Mapper(configuration);
        }
    }
}
