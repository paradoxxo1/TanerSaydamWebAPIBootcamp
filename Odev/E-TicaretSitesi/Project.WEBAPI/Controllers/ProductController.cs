using Microsoft.AspNetCore.Mvc;
using Project.Bll.ManagerServices.Abstracts;
using Project.Entities.Models;
using Project.WEBAPI.Models.Products.RequestModels;
using Project.WEBAPI.Models.Products.ResponseModels;

namespace Project.WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductManager _productManager;

        public ProductController(IProductManager productManager)
        {
            _productManager = productManager;
        }
        [HttpPost]
        public async Task<IActionResult> CreateProdcut(CreateProductRequestModel item)
        {
            Product p = new()
            {
                ProductName = item.ProductName,
                UnitPrice = item.UnitPrice,
                CategoryId = item.CategoryId,
            };

            string result = _productManager.Add(p);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetProduct(int? categoryId)
        {
            List<ProductResponseModel> products;
            if (categoryId.HasValue)
            {
                products = _productManager.Where(x => x.CategoryId == categoryId).Select(x => new ProductResponseModel
                {
                    Id = x.Id,
                    ProductName = x.ProductName,
                    UnitPrice = x.UnitPrice,
                    CategoryName = x.Category.CategoryName
                }).ToList();
            }
            else
            {
                products = _productManager.Select(x => new ProductResponseModel
                {
                    Id = x.Id,
                    ProductName = x.ProductName,
                    UnitPrice = x.UnitPrice,
                    CategoryName = x.Category.CategoryName 
                }).ToList();
            }
            return Ok(products);
        }
    }
}
