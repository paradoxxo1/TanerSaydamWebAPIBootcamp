using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project.Dal.Context;

namespace Project.Bll.DependencyResolves
{
    public static class DbContextServiceInjection
    {
        public static IServiceCollection AddDbContextService(this IServiceCollection services)
        {
            ServiceProvider provider = services.BuildServiceProvider();
            IConfiguration configuration = provider.GetService<IConfiguration>();
            services.AddDbContextPool<Dal.Context.MyContext>(options => options.UseSqlServer(configuration.GetConnectionString("MyConnection")).UseLazyLoadingProxies());

            return services;
        }
    }
}
