using AutoMapper;

namespace Repayabl.Data
{
    public static class RepayablMapper
    {
        public static IMapper GetMapper()
        {
            IConfigurationProvider configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DTOs.User, User>()
                .ForMember(s => s.Created, t => t.Ignore())
                .ForMember(s => s.CreatedBy, t => t.Ignore())
                .ForMember(s => s.IsActive, t => t.Ignore())
                .ForMember(s => s.Properties, t => t.Ignore());
                cfg.CreateMap<User, DTOs.User>();
            });
            return new Mapper(configuration);
        }
    }
}
