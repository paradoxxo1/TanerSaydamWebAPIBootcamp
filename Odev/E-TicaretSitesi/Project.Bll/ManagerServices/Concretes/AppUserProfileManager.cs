using Project.Bll.ManagerServices.Abstracts;
using Project.Dal.Repositories.Abstracts;
using Project.Entities.Models;

namespace Project.Bll.ManagerServices.Concretes
{
    public class AppUserProfileManager : BaseManager<AppUserProfile>, IAppUserProfileManager
    {
        IAppUserProfileRepository _proRep;
        public AppUserProfileManager(IAppUserProfileRepository proRep) : base(proRep)
        {
            _proRep = proRep;
        }
    }
}

