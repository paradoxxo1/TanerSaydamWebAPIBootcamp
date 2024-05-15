using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Project.Dal.Context;
using Project.Entities.Models;

namespace Project.Bll.DependencyResolves
{
    public static class IdentityExtentionService
    {
        public static IServiceCollection AddIdentityService(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, IdentityRole<int>>(x =>
            {
                x.Password.RequiredUniqueChars = 0;
                x.Password.RequiredLength = 8;
                x.Password.RequireNonAlphanumeric = false;
                x.Password.RequireDigit = false;
                x.Password.RequireLowercase = false;
                x.Password.RequireUppercase = false;

            }).AddEntityFrameworkStores<MyContext>();


            return services;
        }
    }
}
