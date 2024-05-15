using Microsoft.Extensions.DependencyInjection;
using Project.Bll.ManagerServices.Abstracts;
using Project.Bll.ManagerServices.Concretes;
using Project.Dal.Repositories.Abstracts;
using Project.Dal.Repositories.Concretes;

namespace Project.Bll.DependencyResolves
{
    public static class RepositoryManagerServiceInjection
    {
        public static IServiceCollection AddRepositoryManagerServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IManager<>), typeof(BaseManager<>));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductManager, ProductManager>();
            services.AddScoped<IAppUserRepository, AppUserRepository>();
            services.AddScoped<IAppUserManager, AppUserManager>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryManager, CategoryManager>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderManager, OrderManager>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<IOrderDetailManager, OrderDetailManager>();
            services.AddScoped<IAppUserProfileRepository, AppUserProfileRepository>();
            services.AddScoped<IAppUserProfileManager, AppUserProfileManager>();

            return services;
        }
    }
}
