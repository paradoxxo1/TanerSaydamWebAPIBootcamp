using Project.Bll.ManagerServices.Abstracts;
using Project.Dal.Repositories.Abstracts;
using Project.Entities.Models;

namespace Project.Bll.ManagerServices.Concretes
{
    public class OrderDetailManager : BaseManager<OrderDetail>, IOrderDetailManager
    {
        IOrderDetailRepository _odRep;
        public OrderDetailManager(IOrderDetailRepository odRep) : base(odRep)
        {
            _odRep = odRep;
        }
    }
}
