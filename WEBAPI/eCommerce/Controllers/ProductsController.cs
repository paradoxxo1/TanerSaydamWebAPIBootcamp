using eCommerce.Abstractions;
using eCommerce.DTOs;
using eCommerce.Models;
using eCommerce.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers
{
    public sealed class ProductsController : APIController
    {
        public static List<Product> Products = new();

        [HttpPost]
        public IActionResult Create(CreateProductDto request)
        {
            bool isNameExists = Products.Any(p => p.Name == request.Name);
            if (isNameExists)
            {
                return BadRequest(Result.Failed("This product name is already exists"));
            }

            if (request.Price <= 0)
            {
                return BadRequest(Result.Failed("Product price must be greater then 0"));
            }

            Product product = new()
            {
                Name = request.Name,
                Price = request.Price,
            };
            Products.Add(product);
            return Ok(Result.Succed("Product create is successfull"));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(Products.OrderBy(p => p.Name));
        }

        [HttpDelete]
        public IActionResult DeleteById(Guid id)
        {
            Product? product = Products.Find(p => p.Id == id);
            if (product is null)
            {
                return BadRequest(Result.Failed("Product not found"));
            }

            Products.Remove(product);

            return Ok(Result.Succed("Product delete is successful"));
        }

        [HttpPut]
        public IActionResult Update(UpdateProductDto request)
        {
            Product? product = Products.Find(p => p.Id == request.Id);

            if (product is null)
            {
                return BadRequest(Result.Failed("Product not found"));
            }

            if (product.Name != request.Name)
            {
                bool isNameExists = Products.Any(p => p.Name == request.Name);
                if (isNameExists)
                {
                    return BadRequest(Result.Failed("This product name is already exists"));
                }
            }

            product.Name = request.Name;
            product.Price = request.Price;

            return Ok(Result.Succed("Product update is successful"));
        }
    }
}
