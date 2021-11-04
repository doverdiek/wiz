
using AbstractModels;
using AutoMapper;
using DataModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using ProductService.Models;
using ProductService.Repos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo productRepo;
        private readonly ICategoryRepo categoryRepo;
        private readonly IWebHostEnvironment environment;
        public ProductService(
            IProductRepo productRepo, 
            ICategoryRepo categoryRepo, 
            IWebHostEnvironment environment
            )
        {
            this.productRepo = productRepo;
            this.categoryRepo = categoryRepo;
            this.environment = environment;
        }
        public void DeleteProduct(string productId)
        {
            productRepo.DeleteRecord(productId);
        }

        public IEnumerable<Product> GetAllProducts(string UserId)
        {
            return productRepo.GetAllDocuments(UserId);
        }

        public Product GetProductDetails(string productId)
        {
            return productRepo.GetSpecificRecord(productId);
        }

        public void SetProductPropertyValue(List<CategoryProperty> categoryProperties, string productId)
        {
            var product = GetProductDetails(productId);
            var category = categoryRepo.GetSpecificRecord(product.Category);
            var allowedProperties = categoryRepo.GetCategoryProperties(category);
            foreach (var property in categoryProperties)
            {
                var propertySelected = allowedProperties.FirstOrDefault(a => a.Name == property.Name);
                if (propertySelected == null)
                {
                    throw new InvalidOperationException("Not allowed property");
                }
                else
                {
                    foreach(var propertyvalue in property.Values)
                    {
                        if (!propertySelected.Values.Contains(propertyvalue))
                            throw new InvalidOperationException("Property value not allowed");
                    }
                }
            }
            productRepo.SetProductPropertyValue(categoryProperties, productId);
        }

        public Product UpsertProduct(Product product)
        {
            return productRepo.UpsertRecord(product);
        }

        public void AddCategory(string categoryId, string productId) 
        {
            productRepo.AddCategory(categoryId, productId);
        }

        public void AddProductImage(IFormFile image, string productId, string userId)
        {
            var imagespath = Path.Combine(environment.ContentRootPath, "wwwroot", userId, productId);
            if (!Directory.Exists(imagespath))
            {
                Directory.CreateDirectory(imagespath);
            }
            var imagepath = Path.Combine(imagespath, image.FileName);
            FileInfo info = new FileInfo(imagepath);
            if (!info.Exists) { 
            using (var filestream = new FileStream(imagepath, FileMode.Create))
            {
                image.CopyTo(filestream);
            }
            var relativepath = Path.Combine(userId, productId, image.FileName);
            productRepo.AddProductImage(relativepath, productId, userId);
            }
        }


        public void DeleteProductImage(string imagepath, string productId, string userId)
        {
            var product = productRepo.GetSpecificRecord(productId);
            if (product.CustomerId == userId) {
                productRepo.DeleteProductImage(product, imagepath);
            var imagespath = Path.Combine(environment.ContentRootPath, "wwwroot", imagepath);
                var image = new FileInfo(imagespath);
                if (image.Exists)
                {
                    image.Delete();
                }
            }
        }
    }
}
