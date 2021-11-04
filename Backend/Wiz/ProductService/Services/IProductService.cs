
using AbstractModels;
using DataModels;
using Microsoft.AspNetCore.Http;

using ProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Services
{
    public interface IProductService
    {
        public IEnumerable<Product> GetAllProducts(string userId);
        public Product GetProductDetails(string productId);
        public void DeleteProduct(string productId);
        public Product UpsertProduct(Product product);
        void SetProductPropertyValue(List<CategoryProperty> categoryProperties, string productId);
        void AddCategory(string categoryId, string productId);
        void AddProductImage(IFormFile image, string productId, string userId);
        void DeleteProductImage(string imagepath, string productId, string userId);

    }
}
