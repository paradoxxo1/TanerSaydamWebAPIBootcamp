using EntityFramworkCore.WebAPI.Context;
using EntityFramworkCore.WebAPI.DTOs;
using EntityFramworkCore.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EntityFramworkCore.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public sealed class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public ProductsController()
        {
            context = new();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Product> products = context.Products.ToList();
            return Ok(products);
        }
        [HttpPost]
        public IActionResult Create(CreateProductDto requst)
        {
            Product prodcut = new Product()
            {
                Name = requst.Name,
                Price = requst.Price
            };

            context.Products.Add(prodcut);
            context.SaveChanges();
            return Created();
        }
    }
}
