using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Project.Bll.MapperProfiles;

namespace Project.Bll.DependencyResolves
{
    public static class MapperInjection
    {
        public static void AddMapperService(this IServiceCollection services)
        {
            MapperConfiguration mapConfiguration = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new CategoryProfile());
            });

            IMapper mapper = mapConfiguration.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
