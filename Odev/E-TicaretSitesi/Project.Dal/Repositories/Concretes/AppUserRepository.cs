using Microsoft.AspNetCore.Identity;
using Project.Dal.Context;
using Project.Dal.Repositories.Abstracts;
using Project.Entities.Models;

namespace Project.Dal.Repositories.Concretes
{
    public class AppUserRepository : BaseRepository<AppUser>, IAppUserRepository
    {
        UserManager<AppUser> _userManager;
        public AppUserRepository(MyContext db, UserManager<AppUser> userManager): base(db)
        {
            _userManager = userManager;
        }

        public async Task<bool> AddUser(AppUser item)
        {
            IdentityResult result = await _userManager.CreateAsync(item, item.PasswordHash);
            if (result.Succeeded) return true;
            return false;
        }
    }
}
