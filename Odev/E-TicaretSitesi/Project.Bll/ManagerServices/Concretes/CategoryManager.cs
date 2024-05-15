using Project.Bll.ManagerServices.Abstracts;
using Project.Dal.Repositories.Abstracts;
using Project.Entities.Models;

namespace Project.Bll.ManagerServices.Concretes
{
    public class CategoryManager : BaseManager<Category>, ICategoryManager
    {
        ICategoryRepository _catRepository;

        public CategoryManager(ICategoryRepository catRepository) : base(catRepository)
        {
            _catRepository = catRepository;
        }
    }
}
