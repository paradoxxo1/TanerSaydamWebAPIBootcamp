using Project.Entities.Models;

namespace Project.Dal.Repositories.Abstracts
{
    public interface IAppUserRepository : IRepository<AppUser>
    {
        Task<bool> AddUser(AppUser item);
    }
}
