using Project.Bll.ManagerServices.Abstracts;
using Project.Dal.Repositories.Abstracts;
using Project.Entities.Models;

namespace Project.Bll.ManagerServices.Concretes
{
    public class OrderManager : BaseManager<Order>, IOrderManager
    {
        IOrderRepository _oRep;
        public OrderManager(IOrderRepository oRep) : base(oRep)
        {
            _oRep = oRep;
        }
    }
}
