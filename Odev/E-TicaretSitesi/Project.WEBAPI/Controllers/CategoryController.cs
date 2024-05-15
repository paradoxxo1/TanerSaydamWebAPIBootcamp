using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Bll.ManagerServices.Abstracts;
using Project.Entities.Models;
using Project.WEBAPI.Models.Categories.RequestModels;
using Project.WEBAPI.Models.Categories.ResponseModels;

namespace Project.WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryManager _categoryManager;

        public CategoryController(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequestModel item)
        {
            Category c = new()
            {
                CategoryName = item.CategoryName,
                Description = item.Description,
            };

            string result = _categoryManager.Add(c);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            List<CategoryResponseModel> categories = _categoryManager.Select(x => new CategoryResponseModel 
            { 
                CategoryName = x.CategoryName, 
                Description = x.Description,
                CategoryId = x.Id
            }).ToList();
            
            return Ok(categories);
        }
    }
}
