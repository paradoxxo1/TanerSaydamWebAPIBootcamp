using Project.Entities.Models;

namespace Project.Bll.ManagerServices.Abstracts
{
    public interface IAppUserManager : IManager<AppUser>
    {
        Task<bool> CreateUserAsync(AppUser item);

    }
}
