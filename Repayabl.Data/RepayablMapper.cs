using AutoMapper;

namespace Repayabl.Data
{
    public static class RepayablMapper
    {
        public static IMapper GetMapper()
        {
            IConfigurationProvider configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DTOs.User, User>();
                cfg.CreateMap<User, DTOs.User>();
            });
            return new Mapper(configuration);
        }
    }
}
