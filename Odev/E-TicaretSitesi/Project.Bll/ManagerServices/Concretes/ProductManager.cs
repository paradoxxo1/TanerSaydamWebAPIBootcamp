using Project.Bll.ManagerServices.Abstracts;
using Project.Dal.Repositories.Abstracts;
using Project.Entities.Models;

namespace Project.Bll.ManagerServices.Concretes
{
    public class ProductManager : BaseManager<Product>, IProductManager
    {
        IProductRepository _proRepo;
        public ProductManager(IProductRepository proRep) : base(proRep)
        {
            _proRepo = proRep;
        }
    }
}
