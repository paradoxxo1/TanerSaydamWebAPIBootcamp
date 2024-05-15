using eCommerce.Abstractions;
using eCommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers
{
    public class OrdersController : APIController
    {
        public static List<Order> Orders = new();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(Orders);
        }
    }
}
