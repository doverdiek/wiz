
using AbstractModels;
using BackOfficeAuth;
using DataModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProductService.Models;
using ProductService.Models.Requests;
using ProductService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ProductController : BackOfficeController
    {
        private readonly IProductService productService;
        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet("All")]
        public List<Product> GetProductCategories()
        {
            return productService.GetAllProducts(UserId).ToList();
        }

        [HttpPost("Upsert")]
        public Product UpsertProduct(Product product)
        {
            product.CustomerId = UserId;
            return productService.UpsertProduct(product);
        }

        [HttpDelete("Delete/{id}")]
        public void DeleteProduct(string id)
        {
            productService.DeleteProduct(id);
        }

        [HttpGet("{id}")]
        public Product GetProductDetails(string id)
        {
            return productService.GetProductDetails(id);
        }

        [HttpPost("SetProductPropertyValue/{productId}")]
        public void SetProductPropertyValue([FromBody]Newtonsoft.Json.Linq.JObject categoryProperties, string productId)
        {
            var categoryPropertiesObject = categoryProperties.GetValue("categoryProperties").ToObject<List<CategoryProperty>>();
            productService.SetProductPropertyValue(categoryPropertiesObject, productId);
        }

        [HttpPost("AddProductImage/{productId}")]
        public void AddProductImage(IFormFile image, string productId)
        {
            productService.AddProductImage(image, productId, UserId);

        }

        [HttpPost("DeleteProductImage")]
        public void DeleteProductImage([FromBody]DeleteProductImage deleteProductImage)
        {
            productService.DeleteProductImage(deleteProductImage.ImagePath, deleteProductImage.ProductId, UserId);
        }
    }
}
