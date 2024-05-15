using Project.Bll.ManagerServices.Abstracts;
using Project.Dal.Repositories.Abstracts;
using Project.Entities.Models;

namespace Project.Bll.ManagerServices.Concretes
{
    public class AppUserManager : BaseManager<AppUser>, IAppUserManager
    {
        IAppUserRepository _apRep;

            public AppUserManager(IAppUserRepository apRep) : base(apRep)
            {
                _apRep = apRep;
            }

            public async Task<bool> CreateUserAsync(AppUser item)
            {
                return await _apRep.AddUser(item);
            }
        }
    }
